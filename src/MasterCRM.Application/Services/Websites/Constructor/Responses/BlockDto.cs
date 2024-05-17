using MasterCRM.Domain.Enums;

namespace MasterCRM.Application.Services.Websites.Constructor.Responses;

public record BlockDto
{
    public required Guid Id { get; init; }
    
    public required BlockType BlockType { get; init; }
    
    public required short Order { get; init; }
    
    public string? Text { get; init; }
    
    public string? H1Text { get; init; }
    
    public string? PText { get; init; }
    
    public string? ImageUrl { get; init; }
    
    public int? Type { get; init; }
}