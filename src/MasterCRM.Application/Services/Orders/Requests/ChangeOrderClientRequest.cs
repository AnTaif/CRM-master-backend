namespace MasterCRM.Application.Services.Orders.Requests;

public class ChangeOrderClientRequest
{
    public required string? FullName { get; init; }
    
    public required string? Email { get; init; }
    
    public required string? Phone { get; init; }
    
    public required string? Address { get; init; }
}