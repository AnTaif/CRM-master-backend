using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Websites.Templates.Responses;

namespace MasterCRM.Application.Services.Websites.Templates;

public class TemplateService(ITemplateRepository templateRepository) : ITemplateService
{
    public async Task<IEnumerable<TemplateDto>> GetTemplates()
    {
        var templates = await templateRepository.GetTemplates();

        return templates.Select(template => template.ToDto());
    }

    public async Task<TemplateDto?> GetTemplate(int id)
    {
        var template = await templateRepository.GetByIdAsync(id);

        return template?.ToDto();
    }
}