using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.Services.Websites.Templates;

public interface ITemplateRepository
{
    public Task<Template?> GetByIdAsync(int id);
}