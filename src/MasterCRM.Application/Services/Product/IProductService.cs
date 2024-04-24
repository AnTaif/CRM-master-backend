using MasterCRM.Application.Services.Product.Requests;
using MasterCRM.Application.Services.Product.Responses;

namespace MasterCRM.Application.Services.Product;

public interface IProductService
{
    public Task<IEnumerable<GetProductResponse>> GetAllProductsAsync(string userId);
    
    public Task<GetProductResponse?> GetProductByIdAsync(Guid productId);

    public Task<CreateProductResponse> CreateAsync(string userId, CreateProductRequest request);

    public Task<ChangeProductResponse?> ChangeAsync(Guid productId, ChangeProductRequest request);

    public Task<bool> TryDeleteAsync(Guid productId);
}