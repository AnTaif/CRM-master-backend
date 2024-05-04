using MasterCRM.Application.Services.Clients.Requests;

namespace MasterCRM.Application.Services.Clients;

public interface IClientService
{
    public Task<IEnumerable<ClientItemResponse>> GetByMasterAsync(string masterId);
    
    public Task<ClientDto?> GetByIdAsync(Guid id);
    
    public Task<bool> TryChangeAsync(Guid id, ChangeClientRequest request);
    
    public Task<bool> TryDeleteAsync(Guid id);
}