namespace MasterCRM.Application.Services.User.Requests;

public record ChangePasswordRequest
{
    public required string NewPassword { get; init; }
 
    /// <summary>
    /// Old user's password
    /// </summary>
    public required string Password { get; init; }
}