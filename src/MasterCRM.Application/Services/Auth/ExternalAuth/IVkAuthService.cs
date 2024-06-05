namespace MasterCRM.Application.Services.Auth.ExternalAuth;

public interface IVkAuthService
{
    public Task<VkLoginResponse?> LoginWithPayloadAsync(string queryPayload);
    
    public Task<VkLoginResponse?> LoginWithRequestAsync(VkLoginRequest request);
    
    public Task<string?> LinkAsync(string userId, VkLoginRequest request);
}

public record VkLoginRequest(string Token, string Uuid);