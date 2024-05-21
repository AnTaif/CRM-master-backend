namespace MasterCRM.Application.Services.Auth.ExternalAuth;

public interface IVkAuthService
{
    public Task<VkLoginResponse?> LoginAsync(string queryPayload);
    
    public Task<string?> LinkAsync(string userId, string queryPayload);
}