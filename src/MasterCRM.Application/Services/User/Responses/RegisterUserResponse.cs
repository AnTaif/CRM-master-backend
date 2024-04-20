namespace MasterCRM.Application.Services.User.Responses;

public record RegisterUserResponse
{
    public required Guid Id { get; init; }
    
    public required string FullName { get; init; }
    
    public required string Email { get; init; }
    
    public required string Phone { get; init; }
    
    public required string? VkLink { get; init; }
    
    public required string? TelegramLink { get; init; }
    
    public required string Token { get; init; }
}