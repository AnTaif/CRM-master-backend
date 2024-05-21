using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Products.Photos.Requests;
using MasterCRM.Application.Services.Products.Requests;
using MasterCRM.Application.Services.Products.Responses;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Products;
using MasterCRM.Domain.Exceptions;
using MasterCRM.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Application.Services.Products;

public class ProductService(IProductRepository repository, IFileStorage fileStorage, UserManager<Master> userManager) : IProductService
{
    public async Task<IEnumerable<ProductDto>> GetUserProductsAsync(string userId)
    {
        var products = await repository.GetByUserIdAsync(userId);

        return products.Select(product => product.ToDto());
    }

    public async Task<IEnumerable<ProductDto>> GetWebsiteProductsAsync(Guid websiteId)
    {
        var master = await userManager.Users.FirstOrDefaultAsync(master => master.WebsiteId == websiteId);

        if (master == null)
            throw new NotFoundException("Master not found");
        
        var products = await repository.GetVisibleByMasterAsync(master.Id);

        return products.Select(product => product.ToDto());
    }

    public async Task<ProductDto?> GetProductByIdAsync(string masterId, Guid productId)
    {
        var product = await repository.GetByIdAsync(productId);

        if (product == null)
            return null;

        if (product.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the product");
        
        return product.ToDto();
    }

    public async Task<ProductDto> CreateAsync(
        string userId, CreateProductRequest request, IEnumerable<UploadPhotoRequest> photoRequests)
    {
        var newProduct = new Product(userId, request.Name, request.Description, request.Dimensions, 
            request.Material.ConvertToMaterial(), request.Price);
        
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

    public async Task<ProductDto?> ChangeAsync(string userId, Guid productId, ChangeProductRequest request)
    {
        var product = await repository.GetByIdAsync(productId);
        
        if (product == null)
            return null;

        if (userId != product.MasterId)
            throw new ForbidException("Current user is not the owner of the product");

        product.Update(request.Name, request.Description, request.Price, request.Material?.ConvertToMaterial(), request.Dimensions);
        await repository.SaveChangesAsync();

        return product.ToDto();
    }

    public async Task<ProductDto?> ToggleVisibility(string masterId, Guid productId)
    {
        var product = await repository.GetByIdAsync(productId);
        
        if (product == null)
            return null;

        if (masterId != product.MasterId)
            throw new ForbidException("Current user is not the owner of the product");
        
        product.ChangeVisibility();
        await repository.SaveChangesAsync();

        return product.ToDto();
    }

    public async Task<bool> TryDeleteAsync(string masterId, Guid productId)
    {
        var product = await repository.GetByIdAsync(productId);

        if (product == null)
            return false;

        if (product.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the product");

        var urls = product.Photos.Select(photo => photo.Url).ToList();

        await repository.DeleteAsync(product);
        await repository.SaveChangesAsync();

        foreach (var url in urls)
            fileStorage.TryDelete(url);

        return true;
    }
}