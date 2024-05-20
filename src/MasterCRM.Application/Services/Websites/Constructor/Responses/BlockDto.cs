namespace MasterCRM.Application.Services.Websites.Constructor.Responses;

public record BlockDto
{
    public required Guid Id { get; init; }
    
    public required string BlockType { get; init; }
    
    public string Title { get; init; }
    
    public required short Order { get; init; }

    public BlockPropertiesDto Properties { get; set; } = null!;
}