using MasterCRM.Application.Services.Orders.Products.Requests;
using MasterCRM.Application.Services.Orders.Products.Responses;

namespace MasterCRM.Application.Services.Orders.Products;

public interface IOrderProductService
{
    public Task<OrderProductDto?> UpdateAsync(Guid orderProductId, OrderProductRequest request);

    public Task<OrderProductDto> CreateAsync(Guid orderId, OrderProductRequest request);

    public Task<bool> TryDeleteAsync(Guid orderProductId);
}