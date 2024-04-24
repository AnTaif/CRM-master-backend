using MasterCRM.Application.Services.Product.Requests;
using MasterCRM.Application.Services.Product.Responses;
using MasterCRM.Domain.Enums;

namespace MasterCRM.Application.Services.Product;

public class ProductService(IProductRepository repository) : IProductService
{
    public async Task<IEnumerable<GetProductResponse>> GetAllProductsAsync(string userId)
    {
        var products = await repository.GetByUserIdAsync(userId);

        var response = products.Select(product => new GetProductResponse
        {
            Id = product.Id,
            UserId = product.MasterId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Material = product.Material.ToString(),
            Dimensions = product.Dimensions ?? "",
            ImageSrc = product.ImageSrc
        });
        return response;
    }

    public async Task<GetProductResponse?> GetProductByIdAsync(Guid productId)
    {
        var product = await repository.GetByIdAsync(productId);

        if (product == null)
            return null;

        var response = new GetProductResponse
        {
            Id = product.Id,
            UserId = product.MasterId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Material = product.Material.ToString(),
            Dimensions = product.Dimensions ?? "",
            ImageSrc = product.ImageSrc
        };
        return response;
    }

    public async Task<CreateProductResponse> CreateAsync(string userId, CreateProductRequest request)
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
            ImageSrc = "" //TODO: add product image uploading
        };

        await repository.CreateAsync(newProduct);

        var response = new CreateProductResponse
        {
            Id = newProduct.Id,
            Name = newProduct.Name,
            Description = newProduct.Description,
            Price = newProduct.Price,
            Material = newProduct.Material.ToString(),
            Dimensions = newProduct.Dimensions,
            ImageSrc = newProduct.ImageSrc
        };
        return response;
    }

    public async Task<ChangeProductResponse?> ChangeAsync(Guid productId, ChangeProductRequest request)
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

        var response = new ChangeProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Material = product.Material.ToString(),
            Dimensions = product.Dimensions ?? "",
            ImageSrc = product.ImageSrc
        };

        return response;
    }

    public async Task<bool> TryDeleteAsync(Guid productId)
    {
        var product = await repository.GetByIdAsync(productId);

        if (product == null)
            return false;
        
        await repository.DeleteAsync(product);
        await repository.SaveChangesAsync();

        return true;
    }
}