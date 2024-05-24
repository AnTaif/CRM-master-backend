using MasterCRM.Application.Services.Websites;
using MasterCRM.Application.Services.Websites.PublicWebsite;
using MasterCRM.Domain.Entities.Websites;
using MasterCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories.Websites;

public class GlobalStylesRepository(CrmDbContext context) : IGlobalStylesRepository
{
    private DbSet<GlobalStyles> dbSet => context.GlobalStyles;

    public async Task<GlobalStyles?> GetWebsiteGlobalStyles(Guid websiteId) => 
        await dbSet.FirstOrDefaultAsync(globalStyles => globalStyles.WebsiteId == websiteId);

    public async Task AddAsync(GlobalStyles styles) => await dbSet.AddAsync(styles);

    public void Update(GlobalStyles styles) => dbSet.Update(styles);
    public void Remove(GlobalStyles styles) => dbSet.Remove(styles);

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}