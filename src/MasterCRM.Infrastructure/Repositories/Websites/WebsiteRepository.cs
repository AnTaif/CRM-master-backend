using MasterCRM.Application.Services.Websites;
using MasterCRM.Application.Services.Websites.PublicWebsite;
using MasterCRM.Domain.Entities.Websites;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories.Websites;

public class WebsiteRepository(CrmDbContext context) : IWebsiteRepository
{
    private DbSet<Website> dbSet => context.Websites;

    public async Task<bool> IsMasterHaveWebsite(string masterId) => 
        await dbSet.AnyAsync(website => website.OwnerId == masterId);

    public async Task<Website?> GetByIdAsync(Guid id) => 
        await dbSet
            .Include(website => website.GlobalStyles)
            .Include(website => website.Components)
                .ThenInclude(component => (component as MultipleTextBlock)!.TextSections)
            .FirstOrDefaultAsync(website => website.Id == id);
    
    public async Task CreateAsync(Website website) => await dbSet.AddAsync(website);

    public void Update(Website website) => dbSet.Update(website);
    
    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}