using MasterCRM.Application.Interfaces;
using MasterCRM.Application.Services.User.Requests;
using MasterCRM.Application.Services.User.Responses;
using MasterCRM.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Application.Services.User;

public class UserService(UserManager<Master> userManager, SignInManager<Master> signInManager) : IUserService
{
    public Task<GetUserInfoResponse> GetInfoAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeInfoAsync(Guid id, ChangeUserInfoRequest request)
    {
        throw new NotImplementedException();
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
            WebsiteId = Guid.NewGuid()
        };

        var result = await userManager.CreateAsync(master, request.Password);
        
        if (!result.Succeeded)
            throw new Exception();
        
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

    public Task<bool> TryChangeEmailAsync(Guid id, ChangeEmailRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> TryChangePasswordAsync(Guid id, ChangePasswordRequest request)
    {
        throw new NotImplementedException();
    }
}