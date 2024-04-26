namespace MasterCRM.Application.Services.User.Requests;

public record ChangePasswordRequest
{
    public required string OldPassword { get; init; }
    
    public required string NewPassword { get; init; }
}