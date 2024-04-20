namespace MasterCRM.Application.Services.Client.Requests;

public record CreateClientRequest
{
    public required string FullName { get; init; }
    
    public required string Email { get; init; }
    
    public required string Phone { get; init; }
}