using MasterCRM.Application.Services.Order.Dto;

namespace MasterCRM.Application.Services.Order.Responses;

public record GetOrderResponse
{
    public required string Name { get; init; }
    
    public required string Stage { get; init; }
    
    public required double TotalAmount { get; init; }
    
    public required string Comment { get; init; }
    
    public required GetOrderClientDto Client { get; init; }
    
    public required IEnumerable<GetOrderProductDto> DealProducts { get; init; }
    
    public required IEnumerable<OrderHistoryDto> History { get; init; }
}