using MasterCRM.Application.Services.User.Requests;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Application.Services.User;

public class UserService(UserManager<Master> userManager) : IUserService
{
    public async Task<UserDto?> GetInfoAsync(string id)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user == null)
            return null;

        return new UserDto
        {
            Id = user.Id,
            FullName = user.GetFullName(),
            Email = user.Email ?? "",
            Phone = user.PhoneNumber ?? "",
            VkLink = user.VkLink,
            TelegramLink = user.TelegramLink,
            VkId = user.VkId?.ToString()
        };
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

        user.PhoneNumber = request.Phone ?? user.PhoneNumber;

        var name = request.FullName?.Split();
        user.LastName = name?[0] ?? user.LastName;
        user.FirstName = name?[1] ?? user.FirstName;
        user.MiddleName = name?.Length > 2 ? name[2] : user.MiddleName;
        user.VkLink = request.VkLink ?? user.VkLink;
        user.TelegramLink = request.TelegramLink ?? user.TelegramLink;

        var result = await userManager.UpdateAsync(user);

        if (!result.Succeeded)
            throw new Exception("Failed to update user info.");

        return new UserDto
        {
            Id = user.Id,
            FullName = user.GetFullName(),
            Email = user.Email ?? "",
            Phone = user.PhoneNumber ?? "",
            VkLink = user.VkLink,
            TelegramLink = user.TelegramLink,
            VkId = user.VkId?.ToString()
        };
    }

    public async Task<bool> TryChangePasswordAsync(string id, ChangePasswordRequest request)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user == null)
            return false;
        
        var result = await userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

        return result.Succeeded;
    }
}