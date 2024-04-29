using MasterCRM.Application.Services.Orders.Dto;

namespace MasterCRM.Application.Services.Orders.Responses;

public record GetOrderResponse
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string Stage { get; init; }
    
    public required double TotalAmount { get; init; }
    
    public required string Comment { get; init; }
    
    public required OrderClientDto Client { get; init; }
    
    public required IEnumerable<OrderProductDto> Products { get; init; }
    
    public required IEnumerable<OrderHistoryDto>? History { get; init; }
}