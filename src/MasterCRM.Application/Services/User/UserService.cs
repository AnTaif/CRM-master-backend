using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.User.Requests;
using MasterCRM.Application.Services.User.Responses;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Application.Services.User;

public class UserService(UserManager<Master> userManager) : IUserService
{
    public async Task<UserDto?> GetInfoAsync(string id)
    {
        var user = await userManager.FindByIdAsync(id);

        return user?.ToDto();
    }

    public async Task<UserDto?> ChangeInfoAsync(string id, ChangeUserInfoRequest request)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user == null)
            return null;

        if (request.Email != null)
        {
            await userManager.SetEmailAsync(user, request.Email);
            await userManager.SetUserNameAsync(user, request.Email);
        }
        
        user.Update(request.FullName, request.Phone, request.VkLink, request.TelegramLink);

        var result = await userManager.UpdateAsync(user);

        if (!result.Succeeded)
            throw new Exception("Failed to update user info.");

        return user.ToDto();
    }

    public async Task<IdentityResult> TryChangePasswordAsync(string id, ChangePasswordRequest request)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user == null)
            throw new NotFoundException("User not found");
        
        var result = await userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

        return result;
    }
}