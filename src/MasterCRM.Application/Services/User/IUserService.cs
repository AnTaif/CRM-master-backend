using MasterCRM.Application.Services.User.Requests;
using MasterCRM.Application.Services.User.Responses;
using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Application.Services.User;

public interface IUserService
{
    public Task<UserDto?> GetInfoAsync(string id);

    public Task<UserDto?> GetInfoByWebsiteAsync(string websiteAddress);

    public Task<UserDto?> ChangeInfoAsync(string id, ChangeUserInfoRequest request);
    
    public Task<IdentityResult> TryChangePasswordAsync(string id, ChangePasswordRequest request);
}