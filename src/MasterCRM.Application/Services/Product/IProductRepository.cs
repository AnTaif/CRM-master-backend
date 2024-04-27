namespace MasterCRM.Application.Services.Product;

public interface IProductRepository
{
    Task<IEnumerable<Domain.Entities.Product>> GetByUserIdAsync(string userId);
    
    Task<Domain.Entities.Product?> GetByIdAsync(Guid id);

    Task CreateAsync(Domain.Entities.Product entity);

    Task DeleteAsync(Domain.Entities.Product entity);

    Task UpdateAsync(Domain.Entities.Product entity);

    Task SaveChangesAsync();
}