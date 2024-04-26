namespace MasterCRM.Application.Services.Auth.Responses;

public record VkLoginResponse(bool HaveAccount, string? FullName, string? Email, string? Phone, int? VkId);