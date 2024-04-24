using System.Text.Json.Nodes;
using MasterCRM.Application.Interfaces;
using MasterCRM.Application.Services.User.Requests;
using MasterCRM.Application.Services.User.Responses;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Application.Services.User;

public class UserService(
    UserManager<Master> userManager, 
    SignInManager<Master> signInManager, 
    IVkontakteService vkontakteService) : IUserService
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

    public async Task<VkLoginResponse?> VkLoginAsync(string queryPayload)
    {
        var payload = JsonNode.Parse(queryPayload);

        if (payload == null)
            throw new Exception();
        
        var silentToken = payload["token"]?.ToString();
        var uuid = payload["uuid"]?.ToString();

        if (silentToken == null || uuid == null)
            throw new Exception();

        var exchangeTokenResponse = await vkontakteService.ExchangeSilentTokenAsync(silentToken, uuid);

        if (exchangeTokenResponse == null)
            throw new Exception();
        
        var vkId = exchangeTokenResponse.UserId;
        var email = exchangeTokenResponse.Email;
        var phone = exchangeTokenResponse.Phone;

        var user = await userManager.Users.FirstOrDefaultAsync(u => u.VkId == vkId);

        if (user == null)
        {
            // Пользователь не найден - необходима регистрация
            var accessToken = exchangeTokenResponse.AccessToken;
            var userInfo = await vkontakteService.GetProfileInfoAsync(accessToken);

            if (userInfo == null)
                throw new Exception();
    
            return new VkLoginResponse(true, $"{userInfo.FirstName} {userInfo.LastName}", email, phone, vkId);
            
            var newUser = new Master
            {
                UserName = exchangeTokenResponse.Email,
                Email = exchangeTokenResponse.Email,
                PhoneNumber = exchangeTokenResponse.Phone ?? "123",
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                VkId = vkId,
            };

            var newUserResult = await userManager.CreateAsync(newUser);
            if (!newUserResult.Succeeded)
                throw new Exception();
            
            await signInManager.SignInAsync(newUser, true, "vk");
        }
        
        await signInManager.SignInAsync(user, true, "vk");
        return new VkLoginResponse(false, null, null, null, null);
    }
}

public record VkLoginResponse(bool HaveAccount, string? FullName, string? Email, string? Phone, int? VkId);