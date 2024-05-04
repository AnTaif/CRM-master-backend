using MasterCRM.Application.Services.Orders.Dto;
using MasterCRM.Application.Services.Orders.Requests;
using MasterCRM.Application.Services.Orders.Responses;
using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.Services.Orders;

public interface IOrderService
{
    public Task<GetOrdersResponse> GetAllByMasterAsync(string masterId);
    
    public Task<GetOrdersResponse> GetWithStageByMasterAsync(string masterId, short orderTab);

    public Task<OrderDto?> GetOrderByIdAsync(Guid orderId);
    
    public Task<OrderDto> CreateOrderAsync(string masterId, CreateOrderRequest request);
    
    public Task<OrderDto?> ChangeOrderAsync(string masterId, Guid orderId, ChangeOrderRequest request);
    
    public Task<bool> TryDeleteOrderAsync(Guid orderId);
}