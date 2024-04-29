using MasterCRM.Application.Services.Orders.Dto;

namespace MasterCRM.Application.Services.Orders.Requests;

public record CreateOrderRequest
{
    public required string Name { get; init; }
    
    public required string Stage { get; init; }
    
    public required double TotalAmount { get; init; }
    
    public required string Comment { get; init; }
    
    public required OrderClientDto Client { get; init; }
    
    public required IEnumerable<OrderProductRequest> OrderProducts { get; init; }
}