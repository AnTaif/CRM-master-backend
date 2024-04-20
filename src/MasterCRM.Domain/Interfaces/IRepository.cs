namespace MasterCRM.Domain.Interfaces;

public interface IRepository<TEntity, in TId> where TEntity : IEntity<TId>
{
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(TId id);

        Task CreateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task SaveChangesAsync();
}