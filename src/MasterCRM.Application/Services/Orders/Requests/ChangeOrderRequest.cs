using MasterCRM.Application.Services.Orders.Products.Requests;

namespace MasterCRM.Application.Services.Orders.Requests;

public record ChangeOrderRequest
{
    public required short? StageTab { get; init; }
    
    public required double? TotalAmount { get; init; }
    
    public required bool? IsCalculationAutomated { get; init; }
    
    public required string? Comment { get; init; }
    
    public required string? Address { get; init; }
    
    // Client info
    public required ChangeOrderClientRequest? Client { get; init; }
    
    // Products info
    public required IEnumerable<OrderProductRequest>? Products { get; init; }
}