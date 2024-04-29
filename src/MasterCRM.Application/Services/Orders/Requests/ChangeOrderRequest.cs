namespace MasterCRM.Application.Services.Orders.Requests;

public record ChangeOrderRequest
{
    public required Guid Id { get; init; }
    
    public required string? Stage { get; init; }
    
    public required double? TotalAmount { get; init; }
    
    public required string? Comment { get; init; }
    
    // Client info
    public required ChangeOrderClientRequest? Client { get; init; }
    
    // Products info
    public required IEnumerable<OrderProductRequest>? Products { get; init; }
}