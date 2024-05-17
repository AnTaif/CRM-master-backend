using MasterCRM.Application.Services.Products.Photos.Requests;
using MasterCRM.Application.Services.Products.Requests;
using MasterCRM.Application.Services.Products.Responses;

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