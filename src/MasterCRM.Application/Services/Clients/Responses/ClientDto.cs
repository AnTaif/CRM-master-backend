using MasterCRM.Application.Services.Orders.Responses;

namespace MasterCRM.Application.Services.Clients.Responses;

public record ClientDto
{
    public required Guid Id { get; init; }
    
    public required string Initials { get; init; }
    
    public required string FullName { get; init; }
    
    public required string Email { get; init; }
    
    public required string Phone { get; init; }
    
    public required DateTime LastOrderDate { get; init; }

    public required IEnumerable<GetOrderItemResponse> Orders { get; init; }
}