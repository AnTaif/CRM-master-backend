namespace MasterCRM.Application.Services.Clients.Responses;

public record GetClientResponse
{
    public required Guid Id { get; init; }
    
    public required string FullName { get; init; }
    
    public required string Email { get; init; }
    
    public required string Phone { get; init; }
    
    public required DateTime LastOrderDate { get; init; }

    // TODO: add orders
    //public required IEnumerable<OrdersDto> Orders { get; init; }
}