using MasterCRM.Application.Services.Auth.Requests;
using MasterCRM.Application.Services.Auth.Responses;
using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Application.Services.Auth;

public interface IAuthService
{
    public Task<SignInResult> RegisterAsync(RegisterUserRequest request);
    
    public Task<SignInResult> LoginAsync(LoginRequest request);
    
    public Task<VkLoginResponse?> VkLoginAsync(string queryPayload);
    
    public Task LogoutAsync();
}