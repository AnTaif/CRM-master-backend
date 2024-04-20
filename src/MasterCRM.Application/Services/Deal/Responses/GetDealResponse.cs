using MasterCRM.Application.Services.Deal.Dto;

namespace MasterCRM.Application.Services.Deal.Responses;

public record GetDealResponse
{
    public required string Name { get; init; }
    
    public required string Stage { get; init; }
    
    public required double TotalAmount { get; init; }
    
    public required string Comment { get; init; }
    
    public required GetDealClientDto Client { get; init; }
    
    public required IEnumerable<GetDealProductDto> DealProducts { get; init; }
    
    public required IEnumerable<DealHistoryDto> History { get; init; }
}