using MasterCRM.Application.Services.Websites.Constructor.Responses;

namespace MasterCRM.Application.Services.Websites.Constructor.Requests;

public class ChangeBlockRequest
{
    public string? Text { get; init; }
    
    public int? Type { get; init; }
    
    public string ? H1Text { get; init; }
    
    public string? PText { get; init; }
    
    public string? ImageUrl { get; init; }
    
    public IEnumerable<TextSectionDto>? TextSections { get; init; }
}