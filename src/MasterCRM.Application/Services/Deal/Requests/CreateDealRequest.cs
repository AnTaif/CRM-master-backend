using MasterCRM.Application.Services.Deal.Dto;

namespace MasterCRM.Application.Services.Deal.Requests;

public record CreateDealRequest
{
    public required string Name { get; init; }
    
    public required string Stage { get; init; }
    
    public required double TotalAmount { get; init; }
    
    public required string Comment { get; init; }
    
    public required GetDealClientDto Client { get; init; }
    
    public required IEnumerable<CreateDealProductDto> DealProducts { get; init; }
}