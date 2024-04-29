using MasterCRM.Application.Services.Orders.Requests;
using MasterCRM.Application.Services.Orders.Responses;

namespace MasterCRM.Application.Services.Orders;

public class OrderService : IOrderService
{
    public Task<IEnumerable<GetOrderResponse>> GetActiveOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetOrderResponse>> GetInactiveOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetOrderResponse> GetOrderByIdAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetOrderResponse> ChangeOrderAsync(ChangeOrderRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> TryDeleteOrderAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }
}