using MasterCRM.Application.Services.User.Requests;

namespace MasterCRM.Application.Services.User;

public interface IUserService
{
    public Task<UserDto?> GetInfoAsync(string id);

    public Task<UserDto?> ChangeInfoAsync(string id, ChangeUserInfoRequest request);
    
    public Task<bool> TryChangePasswordAsync(string id, ChangePasswordRequest request);
}