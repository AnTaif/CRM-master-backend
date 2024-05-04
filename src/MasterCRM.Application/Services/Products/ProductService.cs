using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Products.Dto;
using MasterCRM.Application.Services.Products.Requests;
using MasterCRM.Domain.Entities.Products;
using MasterCRM.Domain.Enums;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Application.Services.Products;

public class ProductService(IProductRepository repository, IFileStorage fileStorage) : IProductService
{
    public async Task<IEnumerable<ProductDto>> GetUserProductsAsync(string userId)
    {
        var products = await repository.GetByUserIdAsync(userId);

        return products.Select(product => product.ToDto());
    }

    public async Task<ProductDto?> GetProductByIdAsync(Guid productId)
    {
        var product = await repository.GetByIdAsync(productId);

        return product?.ToDto();
    }

    public async Task<ProductDto> CreateAsync(
        string userId, CreateProductRequest request, IEnumerable<UploadPhotoRequest> photoRequests)
    {
        var newProduct = new Product(userId, request.Name, request.Description, request.Dimensions, 
            Enum.Parse<Material>(request.Material), request.Price);
        
        foreach (var uploadRequest in photoRequests)
        {
            var fileId = Guid.NewGuid();
            var fileName = fileId + uploadRequest.Extension;
            var url = await fileStorage.UploadAsync(uploadRequest.PhotoStream, fileName);

            var photo = new ProductPhoto
            {
                Id = fileId,
                Order = (short)newProduct.Photos.Count,
                Url = url,
                Extension = uploadRequest.Extension
            };
            newProduct.Photos.Add(photo);
        }
        
        await repository.CreateAsync(newProduct);

        return newProduct.ToDto();
    }

    public async Task<ProductDto?> ChangeAsync(
        Guid productId, ChangeProductRequest request)
    {
        var product = await repository.GetByIdAsync(productId);

        if (product == null)
            return null;

        product.Update(request.Name, request.Description, request.Price, request.Material, request.Dimensions);
        await repository.SaveChangesAsync();

        return product.ToDto();
    }

    public async Task<bool> TryDeleteAsync(Guid productId)
    {
        var product = await repository.GetByIdAsync(productId);

        if (product == null)
            return false;

        var urls = product.Photos.Select(photo => photo.Url).ToList();

        await repository.DeleteAsync(product);
        await repository.SaveChangesAsync();

        foreach (var url in urls)
            fileStorage.TryDelete(url);

        return true;
    }
}