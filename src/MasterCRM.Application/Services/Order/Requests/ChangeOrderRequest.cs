using MasterCRM.Application.Services.Order.Dto;

namespace MasterCRM.Application.Services.Order.Requests;

public record ChangeOrderRequest
{
    public required Guid Id { get; init; }
    
    public required string? Name { get; init; }
    
    public required string? Stage { get; init; }
    
    public required double? TotalAmount { get; init; }
    
    public required string? Comment { get; init; }
    
    // Client info
    public required ChangeOrderClientDto? Client { get; init; }
    
    // Products info
    public required IEnumerable<CreateOrderProductDto>? OrderProducts { get; init; }
}