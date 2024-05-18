using MasterCRM.Application.Services.Websites;
using MasterCRM.Domain.Entities.Websites;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories.Websites;

public class ConstructorBlockRepository(CrmDbContext context) : IConstructorBlockRepository
{
    private DbSet<ConstructorBlock> dbSet => context.ConstructorBlocks;

    public async Task<IEnumerable<ConstructorBlock>> GetWebsiteComponentsAsync(Guid websiteId) =>
        await dbSet.Where(block => block.WebsiteId == websiteId).ToListAsync();

    public async Task<ConstructorBlock?> GetBlockAsync(Guid id) => await dbSet.FirstOrDefaultAsync(block => block.Id == id);

    public async Task AddAsync(ConstructorBlock block) => await dbSet.AddAsync(block);

    public async Task AddRangeAsync(IEnumerable<ConstructorBlock> blocks) => await dbSet.AddRangeAsync(blocks);
    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}