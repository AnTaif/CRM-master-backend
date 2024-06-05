using MasterCRM.Application.Services.Orders.Stages;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;
using MasterCRM.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Application.Services.Auth.ExternalAuth;

public class VkAuthService(
    UserManager<Master> userManager, 
    SignInManager<Master> signInManager, 
    IVkontakteService vkontakteService,
    IStageRepository stageRepository) : IVkAuthService
{
    /// <summary>
    /// Checks silent token and login if user with vkId was found in database,
    /// otherwise - getting user's profile and register a new user with the received info 
    /// </summary>
    /// <param name="queryPayload">Query payload from VK Id response</param>
    public async Task<VkLoginResponse?> LoginWithPayloadAsync(string queryPayload)
    {
        var exchangeTokenResponse = await vkontakteService.ExchangeSilentTokenWithPayloadAsync(queryPayload);

        if (exchangeTokenResponse == null)
            return null;

        return await LoginAsync(exchangeTokenResponse);
    }

    public async Task<VkLoginResponse?> LoginWithRequestAsync(VkLoginRequest request)
    {
        var exchangeTokenResponse = await vkontakteService.ExchangeSilentTokenAsync(request.Token, request.Uuid);

        if (exchangeTokenResponse == null)
            return null;

        return await LoginAsync(exchangeTokenResponse);
    }

    private async Task<VkLoginResponse?> LoginAsync(ExchangeTokenResponse exchangeTokenResponse)
    {
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
                UserName = exchangeTokenResponse.Email ?? $"vk{vkId}",
                Email = exchangeTokenResponse.Email,
                PhoneNumber = exchangeTokenResponse.Phone ?? "",
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                VkId = vkId,
            };
            
            var newUserResult = await userManager.CreateAsync(newUser);
            if (!newUserResult.Succeeded)
                throw new Exception("User creation failed");

            await AddDefaultStagesAsync(newUser.Id);
            
            await signInManager.SignInAsync(newUser, true);
    
            return new VkLoginResponse(false, $"{userInfo.FirstName} {userInfo.LastName}", email, phone, vkId);
        }
        
        await signInManager.SignInAsync(user, true);
        return new VkLoginResponse(true, null, null, null, null);
    }

    public async Task<string?> LinkAsync(string userId, VkLoginRequest request)
    {
        var user = await userManager.FindByIdAsync(userId);
        
        if (user == null)
            throw new Exception("User not found");
        
        var exchangeTokenResponse = await vkontakteService.ExchangeSilentTokenAsync(request.Token, request.Uuid);

        if (exchangeTokenResponse == null)
            throw new Exception("VK token exchange failed");
        
        var vkId = exchangeTokenResponse.UserId;

        var isVkIdAlreadyUsed = await userManager.Users.AnyAsync(master => master.VkId == vkId);

        if (isVkIdAlreadyUsed)
            return null;
        
        user.VkId = vkId;
        
        await userManager.UpdateAsync(user);

        return vkId.ToString();
    }
    
    private async Task AddDefaultStagesAsync(string masterId)
    {
        var defaultStages = new List<Stage>
        {
            new() { MasterId = masterId, Name = "Новый заказ", StageType = StageType.Start, Order = 0 },
            new() { MasterId = masterId, Name = "В работе", StageType = StageType.Default, Order = 1 },
            new() { MasterId = masterId, Name = "Доставка", StageType = StageType.Default, Order = 2 },
            new() { MasterId = masterId, Name = "Архив", StageType = StageType.End, Order = 3 },
        };

        await stageRepository.AddRangeAsync(defaultStages);
        await stageRepository.SaveChangesAsync();
    }
}