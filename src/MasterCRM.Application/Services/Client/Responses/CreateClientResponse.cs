namespace MasterCRM.Application.Services.Client.Responses;

public record CreateClientResponse
{
    public required Guid Id { get; init; }
    
    public required string FullName { get; init; }
    
    public required string Email { get; init; }
    
    public required string? Phone { get; init; }
}