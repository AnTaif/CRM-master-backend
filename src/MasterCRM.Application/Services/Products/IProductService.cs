using MasterCRM.Application.Services.Products.Dto;
using MasterCRM.Application.Services.Products.Requests;

namespace MasterCRM.Application.Services.Products;

public interface IProductService
{
    public Task<IEnumerable<ProductDto>> GetUserProductsAsync(string userId);
    
    public Task<ProductDto?> GetProductByIdAsync(Guid productId);

    public Task<ProductDto> CreateAsync(
        string userId, CreateProductRequest request, IEnumerable<UploadPhotoRequest> photoRequests);

    public Task<ProductDto?> ChangeAsync(string masterId, Guid productId, ChangeProductRequest request);

    public Task<ProductDto?> ToggleVisibility(string masterId, Guid productId);

    public Task<bool> TryDeleteAsync(Guid productId);
}