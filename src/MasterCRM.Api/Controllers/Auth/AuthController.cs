using MasterCRM.Application.Services.Auth.DefaultAuth;
using MasterCRM.Application.Services.Auth.DefaultAuth.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Mvc.SignInResult;

namespace MasterCRM.Api.Controllers.Auth;

[ApiController]
[Route("auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    /// <summary>
    /// Registers a new user with email and password
    /// </summary>
    [HttpPost("register")]
    [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var result = await authService.RegisterAsync(request);

        if (!result.Succeeded)
            return BadRequest();

        return CreatedAtAction(nameof(Register), result);
    }
    
    /// <summary>
    /// Logs in the user using email and password
    /// </summary>
    [HttpPost("login")]
    [ProducesResponseType(typeof(SignInResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await authService.LoginAsync(request);

        if (!result.Succeeded)
            return BadRequest();

        return NoContent();
    }
    
    /// <summary>
    /// Logs out the user
    /// </summary>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();
        return NoContent();
    }
}