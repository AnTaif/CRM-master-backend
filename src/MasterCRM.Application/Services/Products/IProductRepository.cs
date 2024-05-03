using MasterCRM.Domain.Entities.Products;

namespace MasterCRM.Application.Services.Products;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetByUserIdAsync(string userId);
    
    Task<Product?> GetByIdAsync(Guid id);

    Task CreateAsync(Product entity);

    Task DeleteAsync(Product entity);

    Task UpdateAsync(Product entity);

    Task SaveChangesAsync();
}