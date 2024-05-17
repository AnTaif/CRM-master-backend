using MasterCRM.Application.Services.Websites.Templates.Responses;

namespace MasterCRM.Application.Services.Websites.Templates;

public interface ITemplateService
{
    public Task<IEnumerable<GetTemplateItemResponse>> GetTemplates();
    
    public Task<TemplateDto> GetTemplate(int id);
}