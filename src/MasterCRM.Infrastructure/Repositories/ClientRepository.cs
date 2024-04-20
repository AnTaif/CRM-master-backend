using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories;

public class ClientRepository(CrmDbContext context) : IRepository<Client, Guid>
{
    private DbSet<Client> dbSet => context.Clients;
    
    public async Task<IEnumerable<Client>> GetAllAsync() => await dbSet.ToListAsync();

    public async Task<Client?> GetByIdAsync(Guid id) =>
        await dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public async Task CreateAsync(Client entity)
    {
        await dbSet.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Client entity)
    {
        dbSet.Remove(entity);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Client entity)
    {
        dbSet.Update(entity);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}