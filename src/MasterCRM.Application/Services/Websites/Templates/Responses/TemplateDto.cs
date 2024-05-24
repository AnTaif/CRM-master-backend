using MasterCRM.Application.Services.Websites.Constructor.Responses;

namespace MasterCRM.Application.Services.Websites.Templates.Responses;

public record TemplateDto
{
    public required int Id { get; init; }
    
    public required GlobalStylesDto GlobalStyles { get; init; }
    
    public required IEnumerable<BlockDto> Blocks { get; init; }
}