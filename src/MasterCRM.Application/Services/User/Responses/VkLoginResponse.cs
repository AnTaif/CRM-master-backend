namespace MasterCRM.Application.Services.User.Responses;

public record VkLoginResponse(bool HaveAccount, string? FullName, string? Email, string? Phone, int? VkId);