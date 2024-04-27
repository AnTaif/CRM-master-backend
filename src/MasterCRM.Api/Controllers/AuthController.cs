using System.Security.Claims;
using System.Text.Json.Nodes;
using MasterCRM.Application.Services.Auth;
using MasterCRM.Application.Services.Auth.ExternalAuth;
using MasterCRM.Application.Services.Auth.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Mvc.SignInResult;

namespace MasterCRM.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IAuthService authService, IVkAuthService vkAuthService) : ControllerBase
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

        return NoContent();
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
    /// Logs in the user using VK account or creates a new account if it doesn't exist
    /// </summary>
    /// <param name="vkQuery">Query payload from VK ID response</param>
    [HttpPost("externalLogin/vk")]
    public async Task<ActionResult<VkLoginResponse>> VkLogin([FromQuery] JsonObject vkQuery)
    {
        var payloadEncoded = vkQuery["payload"]?.ToString();

        if (string.IsNullOrEmpty(payloadEncoded))
            return BadRequest("Payload parameter is null or empty.");

        var response = await vkAuthService.LoginAsync(payloadEncoded);

        return Ok(response);
    }
    
    /// <summary>
    /// Links VK account to the current user
    /// </summary>
    /// <param name="vkQuery">Query payload from VK ID response</param>
    /// <returns>VK id of the linked account</returns>
    [Authorize]
    [HttpPost("link/vk")]
    public async Task<ActionResult<string>> LinkVkAccount([FromQuery] JsonObject vkQuery)
    {
        var payloadEncoded = vkQuery["payload"]?.ToString();
        
        if (string.IsNullOrEmpty(payloadEncoded))
            return BadRequest("Payload parameter is null or empty.");
        
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return Forbid();
        
        var vkId = await vkAuthService.LinkAsync(userId, payloadEncoded);
        return Ok(vkId);
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