using MasterCRM.Application.Services.User.Requests;
using MasterCRM.Application.Services.User.Responses;

namespace MasterCRM.Application.Services.User;

public interface IUserService
{
    public Task<GetUserInfoResponse?> GetInfoAsync(string id);

    public Task<GetUserInfoResponse?> ChangeInfoAsync(string id, ChangeUserInfoRequest request);
    
    public Task<bool> TryChangePasswordAsync(string id, ChangePasswordRequest request);
}