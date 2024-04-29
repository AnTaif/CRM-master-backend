namespace MasterCRM.Application.Services.Orders.Requests;

public record OrderProductRequest
{
    /// <summary>
    /// Product id
    /// </summary>
    public required Guid ProductId { get; init; }
    
    /// <summary>
    /// Quantity of the selected product
    /// </summary>
    public required int Quantity { get; init; }
}