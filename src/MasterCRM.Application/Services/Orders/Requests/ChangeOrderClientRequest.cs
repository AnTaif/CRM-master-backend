namespace MasterCRM.Application.Services.Orders.Requests;

public record ChangeOrderClientRequest
{
    public string? FullName { get; init; }
    
    public string? Email { get; init; }
    
    public string? Phone { get; init; }
}