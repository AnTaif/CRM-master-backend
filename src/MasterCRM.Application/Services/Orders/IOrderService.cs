using MasterCRM.Application.Services.Orders.Requests;
using MasterCRM.Application.Services.Orders.Responses;

namespace MasterCRM.Application.Services.Orders;

public interface IOrderService
{
    public Task<GetOrdersResponse> GetAllByMasterAsync(string masterId, short? tab = null);

    public Task<OrderDto?> GetOrderByIdAsync(string masterId, Guid orderId);
    
    public Task<OrderDto> CreateOrderAsync(string masterId, CreateOrderRequest request);

    public Task CreateOrderForWebsiteAsync(string websiteAddress, CreateWebsiteOrderRequest request);
    
    public Task<OrderDto?> ChangeOrderAsync(string masterId, Guid orderId, ChangeOrderRequest request);
    
    public Task<bool> TryDeleteOrderAsync(string masterid, Guid orderId);
}