using MasterCRM.Application.Services.Clients.Responses;
using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.MapExtensions;

public static class ClientExtensions
{
    public static ClientDto ToDto(this Client client)
    {
        return new ClientDto
        {
            Id = client.Id,
            Initials = client.Initials,
            FullName = client.GetFullName(),
            Email = client.Email,
            Phone = client.Phone,
            LastOrderDate = client.GetLastOrderDate(),
            Orders = client.Orders.Select(order => order.ToItemResponse())
        };
    }

    public static ClientItemResponse ToItemResponse(this Client client)
    {
        return new ClientItemResponse
        {
            Id = client.Id,
            FullName = client.GetFullName(),
            Email = client.Email,
            Phone = client.Phone,
            LastOrderDate = client.GetLastOrderDate()
        };
    }
}