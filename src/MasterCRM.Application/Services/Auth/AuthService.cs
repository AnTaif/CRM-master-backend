using System.Text.Json.Nodes;
using MasterCRM.Application.Services.Auth.Requests;
using MasterCRM.Application.Services.Auth.Responses;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Application.Services.Auth;

public class AuthService(UserManager<Master> userManager, 
    SignInManager<Master> signInManager, 
    IVkontakteService vkontakteService) : IAuthService
{
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
    
    /// <summary>
    /// Checks silent token and login if user with vkId was found in database,
    /// otherwise - getting user's profile and register a new user with the received info 
    /// </summary>
    /// <param name="queryPayload">Query payload from VK Id response</param>
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
            // User not found - registration is required
            var accessToken = exchangeTokenResponse.AccessToken;
            var userInfo = await vkontakteService.GetProfileInfoAsync(accessToken);

            if (userInfo == null)
                throw new Exception();
            
            var newUser = new Master
            {
                UserName = exchangeTokenResponse.Email,
                Email = exchangeTokenResponse.Email,
                PhoneNumber = exchangeTokenResponse.Phone ?? "",
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                VkId = vkId,
            };
            
            var newUserResult = await userManager.CreateAsync(newUser);
            if (!newUserResult.Succeeded)
                throw new Exception();
            
            await signInManager.SignInAsync(newUser, true, "vk");
    
            return new VkLoginResponse(false, $"{userInfo.FirstName} {userInfo.LastName}", email, phone, vkId);
        }
        
        await signInManager.SignInAsync(user, true, "vk");
        return new VkLoginResponse(true, null, null, null, null);
    }
    
    public async Task LogoutAsync() => await signInManager.SignOutAsync();
}