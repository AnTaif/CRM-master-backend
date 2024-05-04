using MasterCRM.Application.Services.Clients;
using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.MapExtensions;

public static class ClientExtensions
{
    public static ClientDto ToDto(this Client client)
    {
        return new ClientDto
        {
            Id = client.Id,
            FullName = client.GetFullName(),
            Email = client.Email,
            Phone = client.Phone,
            LastOrderDate = client.GetLastOrderDate()
        };
    }
}