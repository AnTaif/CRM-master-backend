using MasterCRM.Application.Services.Websites.Templates.Responses;
using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.MapExtensions;

public static class TemplateExtensions
{
    public static TemplateDto ToDto(this Template template)
    {
        return new TemplateDto
        {
            Id = template.Id,
            GlobalStyles = template.GlobalStyles.ToDto(),
            Blocks = template.Components.Select(block => block.ToDto())
        };
    }
}