using MasterCRM.Application.Services.Clients.Requests;

namespace MasterCRM.Application.Services.Clients;

public interface IClientService
{
    Task<IEnumerable<ClientDto>> GetByMasterAsync(string masterId);
    
    Task<ClientDto?> GetByIdAsync(Guid id);
    
    Task<bool> TryChangeAsync(Guid id, ChangeClientRequest request);
    
    Task<bool> TryDeleteAsync(Guid id);
}