namespace MasterCRM.Application.Services.Auth.ExternalAuth;

public record VkLoginResponse(bool HaveAccount, string? FullName, string? Email, string? Phone, int? VkId);