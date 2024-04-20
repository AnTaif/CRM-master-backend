namespace MasterCRM.Application.Services.Product.Requests;

public record CreateProductRequest
{
    public required string Name { get; init; }
    
    public required string Description { get; init; }
    
    public required double Price { get; init; }

    public required string Material { get; init; }
        
    public required string Dimensions { get; init; }
    
    public required int StockQuantity { get; init; }
}