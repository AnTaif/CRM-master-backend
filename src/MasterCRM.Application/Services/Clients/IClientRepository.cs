using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.Services.Clients;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetByMasterAsync(string masterId);
    
    Task<Client?> GetByIdAsync(Guid id);
    
    Task CreateAsync(Client entity);
    
    Task DeleteAsync(Client entity);
    
    Task UpdateAsync(Client entity);
    
    Task SaveChangesAsync();
}