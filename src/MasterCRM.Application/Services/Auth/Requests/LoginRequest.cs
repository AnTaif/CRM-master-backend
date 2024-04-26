namespace MasterCRM.Application.Services.Auth.Requests;

public record LoginRequest
{
    public required string Email { get; init; }
    
    public required string Password { get; init; }

    public bool RememberMe { get; init; } = false;
}