using MasterCRM.Application.Services.Products.Photos.Responses;

namespace MasterCRM.Application.Services.Products.Responses;

public record ProductDto
{
    public required Guid Id { get; init; }
    
    public required string UserId { get; init; }
    
    public required string Name { get; init; }
    
    public required string Description { get; init; }
    
    public required double Price { get; init; }

    public required string Material { get; init; }
        
    public required string Dimensions { get; init; }
    
    public required bool IsVisible { get; init; }
    
    public required List<ProductPhotoDto> Photos { get; init; }
}