using MasterCRM.Application.Interfaces;
using MasterCRM.Application.Services.User.Requests;
using MasterCRM.Application.Services.User.Responses;
using MasterCRM.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Application.Services.User;

public class UserService(UserManager<Master> userManager, SignInManager<Master> signInManager) : IUserService
{
    public async Task<GetUserInfoResponse?> GetInfoAsync(string id)
    {
        var master = await userManager.FindByIdAsync(id);

        if (master == null)
            return null;

        return new GetUserInfoResponse
        {
            Id = master.Id,
            FullName = master.GetFullName(),
            Email = master.Email!,
            Phone = master.PhoneNumber ?? "",
            VkLink = master.VkLink,
            TelegramLink = master.TelegramLink
        };
    }
    
    public async Task<bool> TryChangeInfoAsync(string id, ChangeUserInfoRequest request)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user == null)
            return false;
        

        user.Email = request.Email ?? user.Email;
        user.PhoneNumber = request.Phone ?? user.PhoneNumber;
        
        var name = request.FullName?.Split();
        user.FirstName = name?[0] ?? user.FirstName;
        user.LastName = name?[1] ?? user.LastName;
        user.MiddleName = name?.Length > 2 ? name[2] : user.MiddleName;
        user.VkLink = request.VkLink ?? user.VkLink;
        user.TelegramLink = request.TelegramLink ?? user.TelegramLink;
        
        var result = await userManager.UpdateAsync(user);

        return result.Succeeded;
    }

    public async Task<SignInResult> RegisterAsync(RegisterUserRequest request)
    {
        var name = request.FullName.Split();
        var master = new Master
        {
            UserName = request.Email,
            Email = request.Email,
            PhoneNumber = request.Phone,
            FirstName = name[0],
            LastName = name[1],
            MiddleName = name.Length > 2 ? name[2] : null,
            VkLink = request.VkLink,
            TelegramLink = request.TelegramLink,
            WebsiteId = Guid.NewGuid()
        };

        var result = await userManager.CreateAsync(master, request.Password);
        
        if (!result.Succeeded)
            throw new Exception("User already exists");
        
        var loginResult = await signInManager.PasswordSignInAsync(
            request.Email, 
            request.Password, 
            true, 
            true);

        return loginResult;
    }

    public async Task<SignInResult> LoginAsync(LoginRequest request)
    {
        var result = await signInManager.PasswordSignInAsync(
            request.Email, 
            request.Password, 
            request.RememberMe, 
            true);

        return result;
    }

    // public Task<bool> TryChangeEmailAsync(Guid id, ChangeEmailRequest request)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<bool> TryChangePasswordAsync(string id, ChangePasswordRequest request)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user == null)
            return false;
        
        var result = await userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);

        return result.Succeeded;
    }
}