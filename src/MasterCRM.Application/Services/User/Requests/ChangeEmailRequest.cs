namespace MasterCRM.Application.Services.User.Requests;

public record ChangeEmailRequest
{
    public required string NewEmail { get; init; }
    
    public required string Password { get; init; }
}