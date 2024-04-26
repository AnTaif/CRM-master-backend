using MasterCRM.Application.Services.Auth;
using MasterCRM.Application.Services.Auth.Requests;
using MasterCRM.Application.Services.Auth.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Mvc.SignInResult;

namespace MasterCRM.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var result = await authService.RegisterAsync(request);

        if (!result.Succeeded)
            return BadRequest();

        return NoContent();
    }
    
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
    /// External logging using VK ID
    /// </summary>
    /// <returns></returns>
    [HttpGet("externalLogin/vk")]
    public async Task<ActionResult<VkLoginResponse>> ExternalVkLogin()
    {
        var payloadEncoded = HttpContext.Request.Query["payload"].ToString();

        if (string.IsNullOrEmpty(payloadEncoded))
            return BadRequest("Payload parameter not found or empty.");

        var response = await authService.VkLoginAsync(payloadEncoded);

        return Ok(response);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();
        return NoContent();
    }
}