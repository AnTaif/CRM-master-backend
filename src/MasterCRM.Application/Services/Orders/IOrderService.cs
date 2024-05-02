using MasterCRM.Application.Services.Orders.Requests;
using MasterCRM.Application.Services.Orders.Responses;
using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.Services.Orders;

public interface IOrderService
{
    public Task<IEnumerable<GetOrderItemResponse>> GetWithStageByMasterAsync(string masterId, int orderTab);

    public Task<GetOrderResponse?> GetOrderByIdAsync(Guid orderId);
    
    public Task<GetOrderResponse> CreateOrderAsync(string masterId, CreateOrderRequest request);
    
    public Task<GetOrderResponse?> ChangeOrderAsync(string masterId, Guid orderId, ChangeOrderRequest request);
    
    public Task<bool> TryDeleteOrderAsync(Guid orderId);
}