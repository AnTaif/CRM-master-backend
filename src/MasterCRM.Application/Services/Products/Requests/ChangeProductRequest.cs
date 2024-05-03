namespace MasterCRM.Application.Services.Products.Requests;

public record ChangeProductRequest
{
    public required string? Name { get; init; }
    
    public required string? Description { get; init; }
    
    public required double? Price { get; init; }

    public required string? Material { get; init; }
        
    public required string? Dimensions { get; init; }
}