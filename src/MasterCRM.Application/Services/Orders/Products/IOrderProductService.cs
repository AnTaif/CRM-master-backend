using MasterCRM.Application.Services.Orders.Products.Requests;
using MasterCRM.Application.Services.Orders.Products.Responses;

namespace MasterCRM.Application.Services.Orders.Products;

public interface IOrderProductService
{
    public Task<OrderProductDto?> UpdateAsync(string masterId, Guid orderProductId, OrderProductRequest request);

    public Task<OrderProductDto> CreateAsync(string masterId, Guid orderId, OrderProductRequest request);

    public Task<bool> TryDeleteAsync(string masterId, Guid orderProductId);
}