using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories;

public class OrderRepository(CrmDbContext context) : IRepository<Order, Guid>
{
    private DbSet<Order> dbSet => context.Orders;
    
    public async Task<IEnumerable<Order>> GetAllAsync() => await dbSet.ToListAsync();

    public async Task<Order?> GetByIdAsync(Guid id) =>
        await dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public async Task CreateAsync(Order entity)
    {
        await dbSet.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Order entity)
    {
        dbSet.Remove(entity);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Order entity)
    {
        dbSet.Update(entity);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}