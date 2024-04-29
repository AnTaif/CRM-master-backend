using MasterCRM.Application.Services.Clients.Requests;
using MasterCRM.Application.Services.Clients.Responses;

namespace MasterCRM.Application.Services.Clients;

public interface IClientService
{
    Task<IEnumerable<GetClientResponse>> GetByMasterAsync(string masterId);
    
    Task<GetClientResponse?> GetByIdAsync(Guid id);
    
    Task<bool> TryChangeAsync(Guid id, ChangeClientRequest request);
    
    Task<bool> TryDeleteAsync(Guid id);
}