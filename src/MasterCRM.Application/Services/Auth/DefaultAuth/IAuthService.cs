using MasterCRM.Application.Services.Auth.DefaultAuth.Requests;
using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Application.Services.Auth.DefaultAuth;

public interface IAuthService
{
    public Task<IdentityResult> RegisterAsync(RegisterUserRequest request);
    
    public Task<SignInResult> LoginAsync(LoginRequest request);
    
    public Task LogoutAsync();
}