namespace MasterCRM.Application.Services.Product.Responses;

public record ChangeProductResponse
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string Description { get; init; }
    
    public required double Price { get; init; }

    public required string Material { get; init; }
        
    public required string Dimensions { get; init; }
    
    public required int StockQuantity { get; init; }
    
    public required string ImageSrc { get; init; }
}