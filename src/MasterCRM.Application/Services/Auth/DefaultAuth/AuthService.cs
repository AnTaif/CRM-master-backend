using MasterCRM.Application.Services.Auth.DefaultAuth.Requests;
using MasterCRM.Application.Services.Orders.Stages;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;
using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Application.Services.Auth.DefaultAuth;

public class AuthService(UserManager<Master> userManager, 
    SignInManager<Master> signInManager,
    IStageRepository stageRepository) : IAuthService
{
    public async Task<IdentityResult> RegisterAsync(RegisterUserRequest request)
    {
        var master = new Master(request.FullName, request.Email, request.Phone, request.VkLink, request.TelegramLink);

        var result = await userManager.CreateAsync(master, request.Password);

        if (!result.Succeeded)
            return result;

        await AddDefaultStagesAsync(master.Id);
        
        var signInResult = await signInManager.PasswordSignInAsync(
            request.Email, request.Password, true, true);

        if (!signInResult.Succeeded)
            throw new Exception("Failed to sign in after registration");

        return result;
    }
    
    public async Task<SignInResult> LoginAsync(LoginRequest request) =>
        await signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, true);
    
    public async Task LogoutAsync() => await signInManager.SignOutAsync();
    
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