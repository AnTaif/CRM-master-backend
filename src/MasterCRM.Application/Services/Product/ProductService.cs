using MasterCRM.Application.Services.Product.Dto;
using MasterCRM.Application.Services.Product.Requests;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Enums;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Application.Services.Product;

public class ProductService(IProductRepository repository, IFileStorage fileStorage) : IProductService
{
    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(string userId)
    {
        var products = await repository.GetByUserIdAsync(userId);

        var response = products.Select(product => new ProductDto
        {
            Id = product.Id,
            UserId = product.MasterId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Material = product.Material.ToString(),
            Dimensions = product.Dimensions ?? "",
            Photos = product.Photos.Select(p => new ProductPhotoDto(p.Id, p.Url)).ToList()
        });
        return response;
    }

    public async Task<ProductDto?> GetProductByIdAsync(Guid productId)
    {
        var product = await repository.GetByIdAsync(productId);

        if (product == null)
            return null;

        var response = new ProductDto
        {
            Id = product.Id,
            UserId = product.MasterId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Material = product.Material.ToString(),
            Dimensions = product.Dimensions ?? "",
            Photos = product.Photos.Select(p => new ProductPhotoDto(p.Id, p.Url)).ToList()
        };
        return response;
    }

    public async Task<List<ProductPhotoDto>?> AddPhotosToProductAsync(Guid productId, IEnumerable<UploadPhotoRequest> request)
    {
        var product = await repository.GetByIdAsync(productId);

        if (product == null)
            return null;

        var dtos = new List<ProductPhotoDto>();
        foreach (var uploadRequest in request)
        {
            var fileId = Guid.NewGuid();
            var fileName = fileId + uploadRequest.Extension;
            var url = await fileStorage.UploadAsync(uploadRequest.PhotoStream, fileName);

            var photo = new ProductPhoto
            {
                Id = fileId,
                Url = url,
                Extension = uploadRequest.Extension
            };
            product.Photos.Add(photo);
            dtos.Add(new ProductPhotoDto(fileId, url));
        }

        await repository.SaveChangesAsync();
        return dtos;
    }

    public async Task<ProductDto> CreateAsync(
        string userId, CreateProductRequest request, IEnumerable<UploadPhotoRequest> photoRequests)
    {
        var newProduct = new Domain.Entities.Product
        {
            Id = Guid.NewGuid(),
            MasterId = userId,
            Name = request.Name,
            Description = request.Description,
            Dimensions = request.Dimensions,
            Material = Enum.Parse<Material>(request.Material),
            Price = request.Price,
            CreationDate = DateTime.UtcNow,
            Photos = new List<ProductPhoto>(),
        };
        
        foreach (var uploadRequest in photoRequests)
        {
            var fileId = Guid.NewGuid();
            var fileName = fileId + uploadRequest.Extension;
            var url = await fileStorage.UploadAsync(uploadRequest.PhotoStream, fileName);

            var photo = new ProductPhoto
            {
                Id = fileId,
                Url = url,
                Extension = uploadRequest.Extension
            };
            newProduct.Photos.Add(photo);
        }
        
        await repository.CreateAsync(newProduct);

        var response = new ProductDto
        {
            Id = newProduct.Id,
            UserId = userId,
            Name = newProduct.Name,
            Description = newProduct.Description,
            Price = newProduct.Price,
            Material = newProduct.Material.ToString(),
            Dimensions = newProduct.Dimensions,
            Photos = newProduct.Photos.Select(p => new ProductPhotoDto(p.Id, p.Url)).ToList()
        };
        return response;
    }

    public async Task<ProductDto?> ChangeAsync(
        Guid productId, ChangeProductRequest request)
    {
        var product = await repository.GetByIdAsync(productId);

        if (product == null)
            return null;

        product.Name = request.Name ?? product.Name;
        product.Description = request.Description ?? product.Description;
        product.Price = request.Price ?? product.Price;
        if (request.Material != null)
            product.Material = Enum.Parse<Material>(request.Material);
        product.Dimensions = request.Dimensions ?? product.Dimensions;
        //TODO: change image

        await repository.UpdateAsync(product);
        await repository.SaveChangesAsync();

        var response = new ProductDto
        {
            Id = product.Id,
            UserId = product.MasterId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Material = product.Material.ToString(),
            Dimensions = product.Dimensions ?? "",
            Photos = product.Photos.Select(p => new ProductPhotoDto(p.Id, p.Url)).ToList()
        };

        return response;
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

    public async Task<bool> TryDeletePhotoAsync(Guid productId, Guid photoId)
    {
        var product = await repository.GetByIdAsync(productId);

        var photo = product?.Photos.FirstOrDefault(photo => photo.Id == photoId);
        
        if (photo == null)
            return false;

        product!.Photos.Remove(photo);
        await repository.SaveChangesAsync();
        return fileStorage.TryDelete(photo.Url);
    }
}

public record UploadPhotoRequest(Stream PhotoStream, string Extension);
