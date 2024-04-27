using MasterCRM.Application.Services.Product;
using MasterCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories;

public class ProductRepository(CrmDbContext context) : IProductRepository
{
    private DbSet<Product> dbSet => context.Products;
    
    public async Task<IEnumerable<Product>> GetByUserIdAsync(string userId) => 
        await dbSet.Include(p => p.Photos).Where(p => p.MasterId == userId).ToListAsync();

    public async Task<Product?> GetByIdAsync(Guid id) =>
        await dbSet.Include(product => product.Photos).FirstOrDefaultAsync(e => e.Id == id);

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