using MasterCRM.Application.Services.Clients;
using MasterCRM.Domain.Entities;
using MasterCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories.Clients;

public class ClientRepository(CrmDbContext context) : IClientRepository
{
    private DbSet<Client> dbSet => context.Clients;
    
    public async Task<IEnumerable<Client>> GetByMasterAsync(string masterId) => 
        await dbSet.Include(client => client.Orders).Where(client => client.MasterId == masterId).ToListAsync();

    public async Task<Client?> GetByEmailAsync(string email) =>
        await dbSet.Include(client => client.Orders).FirstOrDefaultAsync(client => client.Email == email);

    public async Task<Client?> GetByIdAsync(Guid id) =>
        await dbSet
            .Include(client => client.Orders)
            .ThenInclude(order => order.Stage)
            .FirstOrDefaultAsync(client => client.Id == id);

    public async Task CreateAsync(Client client) => await dbSet.AddAsync(client);

    public void Delete(Client client) => dbSet.Remove(client);

    public void Update(Client client) => dbSet.Update(client);

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}