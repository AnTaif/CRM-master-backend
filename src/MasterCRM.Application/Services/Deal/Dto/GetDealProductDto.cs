namespace MasterCRM.Application.Services.Deal.Dto;

public record GetDealProductDto
{
    /// <summary>
    /// Product id
    /// </summary>
    public required Guid ProductId { get; init; }
    
    /// <summary>
    /// Quantity of the selected product
    /// </summary>
    public required int Quantity { get; init; }
    
    /// <summary>
    /// Product name
    /// </summary>
    public required string Name { get; init; }
    
    /// <summary>
    /// Product image source link
    /// </summary>
    public required string ImageSrc { get; init; } 
}