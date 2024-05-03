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
        var name = request.FullName.Split();
        var master = new Master
        {
            Id = Guid.NewGuid().ToString(),
            UserName = request.Email,
            Email = request.Email,
            PhoneNumber = request.Phone,
            LastName = name[0],
            FirstName = name[1],
            MiddleName = name.Length > 2 ? name[2] : null,
            VkLink = request.VkLink,
            TelegramLink = request.TelegramLink,
            WebsiteId = Guid.NewGuid()
        };

        var result = await userManager.CreateAsync(master, request.Password);
        
        if (!result.Succeeded)
            throw new Exception("User already exists");

        var preCreatedStages = new List<Stage>
        {
            new()
            {
                Id = Guid.NewGuid(),
                MasterId = master.Id,
                Name = "Новый заказ",
                StageType = StageType.Start,
                Order = 0
            },
            new()
            {
                Id = Guid.NewGuid(),
                MasterId = master.Id,
                Name = "В работе",
                StageType = StageType.Default,
                Order = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                MasterId = master.Id,
                Name = "Доставка",
                StageType = StageType.Default,
                Order = 2
            },
            new()
            {
                Id = Guid.NewGuid(),
                MasterId = master.Id,
                Name = "Архив",
                StageType = StageType.End,
                Order = 3
            },
        };

        await stageRepository.AddRangeAsync(preCreatedStages);
        await stageRepository.SaveChangesAsync();
        
        var signInResult = await signInManager.PasswordSignInAsync(
            request.Email, 
            request.Password, 
            true, 
            true);

        if (!signInResult.Succeeded)
            throw new Exception("Failed to sign in after registration");

        return result;
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
    
    public async Task LogoutAsync() => await signInManager.SignOutAsync();
}