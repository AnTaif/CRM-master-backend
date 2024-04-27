using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Application.Services.Auth.ExternalAuth;

public class VkAuthService(
    UserManager<Master> userManager, 
    SignInManager<Master> signInManager, 
    IVkontakteService vkontakteService) : IVkAuthService
{
    /// <summary>
    /// Checks silent token and login if user with vkId was found in database,
    /// otherwise - getting user's profile and register a new user with the received info 
    /// </summary>
    /// <param name="queryPayload">Query payload from VK Id response</param>
    public async Task<VkLoginResponse?> LoginAsync(string queryPayload)
    {
        var exchangeTokenResponse = await vkontakteService.ExchangeSilentTokenAsync(queryPayload);

        if (exchangeTokenResponse == null)
            throw new Exception("VK token exchange failed");
        
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
                throw new Exception("VK user info request failed");
            
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
                throw new Exception("User creation failed");
            
            await signInManager.SignInAsync(newUser, true);
    
            return new VkLoginResponse(false, $"{userInfo.FirstName} {userInfo.LastName}", email, phone, vkId);
        }
        
        await signInManager.SignInAsync(user, true);
        return new VkLoginResponse(true, null, null, null, null);
    }

    public async Task<string> LinkAsync(string userId, string queryPayload)
    {
        var exchangeTokenResponse = await vkontakteService.ExchangeSilentTokenAsync(queryPayload);

        if (exchangeTokenResponse == null)
            throw new Exception("VK token exchange failed");
        
        var vkId = exchangeTokenResponse.UserId;

        var isVkIdAlreadyUsed = await userManager.Users.AnyAsync(user => user.VkId == vkId);

        if (isVkIdAlreadyUsed)
            throw new Exception("VK ID is already used by another user");
        
        var user = await userManager.FindByIdAsync(userId);
        
        if (user == null)
            throw new Exception("User not found");
        
        user.VkId = vkId;
        
        await userManager.UpdateAsync(user);

        return vkId.ToString();
    }
}