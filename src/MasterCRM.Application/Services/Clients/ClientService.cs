using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Clients.Requests;
using MasterCRM.Application.Services.Clients.Responses;
using MasterCRM.Domain.Exceptions;

namespace MasterCRM.Application.Services.Clients;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    public async Task<GetClientsResponse> GetByMasterAsync(string masterId)
    {
        var clients = await clientRepository.GetByMasterAsync(masterId);

        var clientsArray = clients.ToArray();
        return new GetClientsResponse(clientsArray.Length, clientsArray.Select(client => client.ToItemResponse()));
    }

    public async Task<ClientDto?> GetByIdAsync(string masterId, Guid id)
    {
        var client = await clientRepository.GetByIdAsync(id);

        if (client == null)
            return null;

        if (client.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the client");
        
        return client.ToDto();
    }
    
    public async Task<ClientItemResponse?> ChangeAsync(string masterId, Guid id, ChangeClientRequest request)
    {
        var client = await clientRepository.GetByIdAsync(id);
        
        if (client == null)
            return null;
        
        if (client.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the client");
        
        client.Update(request.FullName, request.Email, request.Phone);
        
        await clientRepository.SaveChangesAsync();
        return client.ToItemResponse();
    }

    public async Task<bool> TryDeleteAsync(string masterId, Guid id)
    {
        var client = await clientRepository.GetByIdAsync(id);
        
        if (client == null)
            return false;
        
        if (client.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the client");
        
        clientRepository.Delete(client);
        await clientRepository.SaveChangesAsync();
        
        return true;
    }
}