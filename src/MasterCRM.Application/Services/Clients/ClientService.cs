using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Clients.Requests;

namespace MasterCRM.Application.Services.Clients;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    public async Task<GetClientsResponse> GetByMasterAsync(string masterId)
    {
        var clients = await clientRepository.GetByMasterAsync(masterId);

        var clientsArray = clients.ToArray();
        return new GetClientsResponse(clientsArray.Length, clientsArray.Select(client => client.ToItemResponse()));
    }

    public async Task<ClientDto?> GetByIdAsync(Guid id)
    {
        var client = await clientRepository.GetByIdAsync(id);
        
        return client?.ToDto();
    }
    
    public async Task<bool> TryChangeAsync(Guid id, ChangeClientRequest request)
    {
        var client = await clientRepository.GetByIdAsync(id);
        
        if (client == null)
            return false;
        
        //TODO: add history to client's orders
        client.Update(request.FullName, request.Email, request.Phone);
        
        await clientRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> TryDeleteAsync(Guid id)
    {
        var client = await clientRepository.GetByIdAsync(id);
        
        if (client == null)
            return false;
        
        clientRepository.Delete(client);
        await clientRepository.SaveChangesAsync();
        
        return true;
    }
}