using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories;

public class ProductRepository(CrmDbContext context) : IRepository<Product, Guid>
{
    private DbSet<Product> dbSet => context.Products;
    
    public async Task<IEnumerable<Product>> GetAllAsync() => await dbSet.ToListAsync();

    public async Task<Product?> GetByIdAsync(Guid id) =>
        await dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public async Task CreateAsync(Product entity)
    {
        await dbSet.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Product entity)
    {
        dbSet.Remove(entity);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Product entity)
    {
        dbSet.Update(entity);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}