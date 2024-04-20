using MasterCRM.Application.Services.Deal.Dto;

namespace MasterCRM.Application.Services.Deal.Requests;

public record ChangeDealRequest
{
    public required Guid Id { get; init; }
    
    public required string? Name { get; init; }
    
    public required string? Stage { get; init; }
    
    public required double? TotalAmount { get; init; }
    
    public required string? Comment { get; init; }
    
    // Client info
    public required ChangeDealClientDto? Client { get; init; }
    
    // Products info
    public required IEnumerable<CreateDealProductDto>? DealProducts { get; init; }
}