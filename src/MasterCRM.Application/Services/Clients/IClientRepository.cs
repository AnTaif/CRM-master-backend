using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.Services.Clients;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetByMasterAsync(string masterId);
    
    Task<Client?> GetByEmailAsync(string email);
    
    Task<Client?> GetByIdAsync(Guid id);
    
    Task CreateAsync(Client? client);
    
    void Delete(Client? client);
    
    void Update(Client? client);
    
    Task SaveChangesAsync();
}