namespace MasterCRM.Application.Services.User.Requests;

public record ChangeUserInfoRequest
{
    public required string? FullName { get; init; }
    
    public required string? Email { get; init; }
    
    public required string? Phone { get; init; }
    
    public required string? VkLink { get; init; }
    
    public required string? TelegramLink { get; init; }
}