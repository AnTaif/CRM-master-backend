using MasterCRM.Application.Services.Auth.DefaultAuth;
using MasterCRM.Application.Services.Auth.DefaultAuth.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Auth;

[ApiController]
[Route("auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    /// <summary>
    /// Registers a new user with email and password
    /// </summary>
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IDictionary<string, string[]>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var result = await authService.RegisterAsync(request);

        if (result.Succeeded) 
            return CreatedAtAction(nameof(Register), null);
        
        var errors = result.Errors.ToDictionary(e => e.Code, e => new[] { e.Description });
        return BadRequest(errors);
    }
    
    /// <summary>
    /// Logs in the user using email and password
    /// </summary>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await authService.LoginAsync(request);

        if (!result.Succeeded)
            return BadRequest("Invalid login attempt");

        return NoContent();
    }
    
    /// <summary>
    /// Logs out the user
    /// </summary>
    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();
        return NoContent();
    }
}