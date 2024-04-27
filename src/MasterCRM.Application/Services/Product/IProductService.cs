using MasterCRM.Application.Services.Product.Dto;
using MasterCRM.Application.Services.Product.Requests;

namespace MasterCRM.Application.Services.Product;

public interface IProductService
{
    public Task<IEnumerable<ProductDto>> GetUserProductsAsync(string userId);
    
    public Task<ProductDto?> GetProductByIdAsync(Guid productId);

    public Task<List<ProductPhotoDto>?> AddPhotosToProductAsync(Guid productId, IEnumerable<UploadPhotoRequest> request);

    public Task<ProductDto> CreateAsync(
        string userId, CreateProductRequest request, IEnumerable<UploadPhotoRequest> photoRequests);

    public Task<ProductDto?> ChangeAsync(Guid productId, ChangeProductRequest request);

    public Task<bool> TryDeleteAsync(Guid productId);

    public Task<bool> TryDeletePhotoAsync(Guid productId, Guid photoId);
}