namespace MasterCRM.Application.Services.Clients.Requests;

public record ChangeClientRequest
{
    public required string? FullName { get; init; }
    
    public required string? Email { get; init; }
    
    public required string? Phone { get; init; }
}