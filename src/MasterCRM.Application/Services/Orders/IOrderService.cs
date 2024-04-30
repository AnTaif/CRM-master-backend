using MasterCRM.Application.Services.Orders.Requests;
using MasterCRM.Application.Services.Orders.Responses;

namespace MasterCRM.Application.Services.Orders;

public interface IOrderService
{
    public Task<IEnumerable<GetOrderItemResponse>> GetActiveByMasterAsync(string masterId);
    
    public Task<IEnumerable<GetOrderItemResponse>> GetInactiveByMasterAsync(string masterId);

    public Task<GetOrderResponse?> GetOrderByIdAsync(Guid orderId);
    
    public Task<GetOrderResponse> CreateOrderAsync(string masterId, CreateOrderRequest request);
    
    public Task<GetOrderResponse> ChangeOrderAsync(string masterId, Guid orderId, ChangeOrderRequest request);
    
    public Task<bool> TryDeleteOrderAsync(Guid orderId);
}