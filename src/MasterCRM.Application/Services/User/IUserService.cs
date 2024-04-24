using MasterCRM.Application.Services.User.Requests;
using MasterCRM.Application.Services.User.Responses;
using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Application.Services.User;

public interface IUserService
{
    public Task<GetUserInfoResponse?> GetInfoAsync(string id);

    public Task<bool> TryChangeInfoAsync(string id, ChangeUserInfoRequest request);
    
    public Task<SignInResult> RegisterAsync(RegisterUserRequest request);
    
    public Task<SignInResult> LoginAsync(LoginRequest request);
        
    //public Task<bool> TryChangeEmailAsync(Guid id, ChangeEmailRequest request);
    
    public Task<bool> TryChangePasswordAsync(string id, ChangePasswordRequest request);

    public Task<VkLoginResponse?> VkLoginAsync(string queryPayload);
}