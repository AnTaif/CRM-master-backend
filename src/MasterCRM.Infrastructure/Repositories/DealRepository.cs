using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories;

public class DealRepository(CrmDbContext context) : IRepository<Deal, Guid>
{
    private DbSet<Deal> dbSet => context.Deals;
    
    public async Task<IEnumerable<Deal>> GetAllAsync() => await dbSet.ToListAsync();

    public async Task<Deal?> GetByIdAsync(Guid id) =>
        await dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public async Task CreateAsync(Deal entity)
    {
        await dbSet.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Deal entity)
    {
        dbSet.Remove(entity);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Deal entity)
    {
        dbSet.Update(entity);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}