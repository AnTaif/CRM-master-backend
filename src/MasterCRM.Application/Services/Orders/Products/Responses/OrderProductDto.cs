namespace MasterCRM.Application.Services.Orders.Products.Responses;

public record OrderProductDto
{
    public Guid Id { get; init; }
    
    /// <summary>
    /// Product id
    /// </summary>
    public required Guid ProductId { get; init; }
    
    /// <summary>
    /// Quantity of the selected product
    /// </summary>
    public required int Quantity { get; init; }
    
    public required double UnitPrice { get; init; }
    
    /// <summary>
    /// Product name
    /// </summary>
    public required string Name { get; init; }
    
    /// <summary>
    /// Product image source link
    /// </summary>
    public required string? Photo { get; init; } 
}