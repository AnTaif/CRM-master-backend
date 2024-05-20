using MasterCRM.Application.Services.Websites.Templates;
using MasterCRM.Domain.Entities.Websites;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories.Websites;

public class TemplateRepository(CrmDbContext context) : ITemplateRepository
{
    private DbSet<Template> dbSet => context.Templates;

    public async Task<Template?> GetByIdAsync(int id) => 
        await dbSet
            .Include(template => template.GlobalStyles)
            .Include(template => template.Components)
                .ThenInclude(component => (component as MultipleTextBlock)!.TextSections)
            .FirstOrDefaultAsync(template => template.Id == id);
}