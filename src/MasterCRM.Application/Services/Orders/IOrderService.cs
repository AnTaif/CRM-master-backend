using MasterCRM.Application.Services.Orders.Requests;
using MasterCRM.Application.Services.Orders.Responses;

namespace MasterCRM.Application.Services.Orders;

public interface IOrderService
{
    public Task<IEnumerable<GetOrderResponse>> GetActiveOrdersAsync();
    
    public Task<IEnumerable<GetOrderResponse>> GetInactiveOrdersAsync();

    public Task<GetOrderResponse> GetOrderByIdAsync(Guid orderId);
    
    public Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request);
    
    public Task<GetOrderResponse> ChangeOrderAsync(ChangeOrderRequest request);
    
    public Task<bool> TryDeleteOrderAsync(Guid orderId);
}