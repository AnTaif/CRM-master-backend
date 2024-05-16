using MasterCRM.Application.Services.Websites.PublicWebsite;
using MasterCRM.Domain.Entities.Websites;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories;

public class ConstructorBlockRepository(CrmDbContext context) : IConstructorBlockRepository
{
    private DbSet<ConstructorBlock> dbSet => context.ConstructorBlocks;

    public async Task AddAsync(ConstructorBlock block) => await dbSet.AddAsync(block);

    public async Task AddRangeAsync(IEnumerable<ConstructorBlock> blocks) => await dbSet.AddRangeAsync(blocks);
}