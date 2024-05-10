using MasterCRM.Application.Services.Websites.Templates;
using MasterCRM.Domain.Entities.Websites;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories;

public class TemplateRepository(CrmDbContext context) : ITemplateRepository
{
    private DbSet<Template> dbSet => context.Templates;

    public async Task<Template?> GetByIdAsync(int id) => await dbSet.FirstOrDefaultAsync(template => template.Id == id);
}