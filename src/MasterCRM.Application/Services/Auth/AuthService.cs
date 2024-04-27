using MasterCRM.Application.Services.Auth.Requests;
using MasterCRM.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Application.Services.Auth;

public class AuthService(UserManager<Master> userManager, 
    SignInManager<Master> signInManager) : IAuthService
{
    public async Task<SignInResult> RegisterAsync(RegisterUserRequest request)
    {
        var name = request.FullName.Split();
        var master = new Master
        {
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
    
    public async Task LogoutAsync() => await signInManager.SignOutAsync();
}