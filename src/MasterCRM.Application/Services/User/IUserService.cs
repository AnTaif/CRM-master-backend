using MasterCRM.Application.Services.User.Requests;
using MasterCRM.Application.Services.User.Responses;
using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Application.Interfaces;

public interface IUserService
{
    public Task<GetUserInfoResponse> GetInfoAsync(Guid id);

    public Task<bool> ChangeInfoAsync(Guid id, ChangeUserInfoRequest request);
    
    public Task<SignInResult> RegisterAsync(RegisterUserRequest request);
    
    public Task<SignInResult> LoginAsync(LoginRequest request);
    
    public Task<bool> TryChangeEmailAsync(Guid id, ChangeEmailRequest request);
    
    public Task<bool> TryChangePasswordAsync(Guid id, ChangePasswordRequest request);
}