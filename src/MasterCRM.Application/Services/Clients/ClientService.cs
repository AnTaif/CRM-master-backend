using MasterCRM.Application.Services.Clients.Requests;
using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.Services.Clients;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    public async Task<IEnumerable<ClientDto>> GetByMasterAsync(string masterId)
    {
        var clients = await clientRepository.GetByMasterAsync(masterId);
        
        return clients.Select(client => new ClientDto
        {
            Id = client.Id,
            FullName = client.GetFullName(),
            Email = client.Email,
            Phone = client.Phone,
            LastOrderDate = client.LastOrderDate
        });
    }

    public async Task<ClientDto?> GetByIdAsync(Guid id)
    {
        var client = await clientRepository.GetByIdAsync(id);
        
        if (client == null)
            return null;

        return new ClientDto
        {
            Id = client.Id,
            FullName = client.GetFullName(),
            Email = client.Email,
            Phone = client.Phone,
            LastOrderDate = client.LastOrderDate
        };
    }

    public async Task<bool> TryChangeAsync(Guid id, ChangeClientRequest request)
    {
        var client = await clientRepository.GetByIdAsync(id);
        
        if (client == null)
            return false;

        var name = request.FullName?.Split();
        client.LastName = name?[0] ?? client.LastName;
        client.FirstName = name?[1] ?? client.FirstName;
        client.MiddleName = name?.Length > 2 ? name[2] : null;

        client.Email = request.Email ?? client.Email;
        client.Phone = request.Phone ?? client.Phone;
        
        clientRepository.Update(client);
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