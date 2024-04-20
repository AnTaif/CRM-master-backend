namespace MasterCRM.Application.Services.Deal.Dto;

public record CreateDealProductDto
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