using MasterCRM.Application.Services.Websites;
using MasterCRM.Domain.Entities.Websites;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories.Websites;

public class ConstructorBlockRepository(CrmDbContext context) : IConstructorBlockRepository
{
    private DbSet<ConstructorBlock> dbSet => context.ConstructorBlocks;

    public async Task<IEnumerable<ConstructorBlock>> GetWebsiteComponentsAsync(Guid websiteId) =>
        await dbSet
            .Where(block => block.WebsiteId == websiteId)
            .OrderBy(block => block.Order)
            .ToListAsync();

    public async Task<ConstructorBlock?> GetBlockAsync(Guid id) => await dbSet.FirstOrDefaultAsync(block => block.Id == id);

    public async Task<IEnumerable<TextSection>> GetTextSectionByBlockAsync(Guid id) =>
        await context.Set<TextSection>().Where(section => section.MultipleTextBlockId == id).ToListAsync();

    public void RemoveSections(IEnumerable<TextSection> sections) =>
        context.Set<TextSection>().RemoveRange(sections);

    public async Task AddSectionsAsync(IEnumerable<TextSection> sections) =>
        await context.Set<TextSection>().AddRangeAsync(sections);

    public async Task AddAsync(ConstructorBlock block) => await dbSet.AddAsync(block);

    public async Task AddRangeAsync(IEnumerable<ConstructorBlock> blocks) => await dbSet.AddRangeAsync(blocks);
    public void RemoveRangeAsync(IEnumerable<ConstructorBlock> blocks) => dbSet.RemoveRange(blocks);

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}