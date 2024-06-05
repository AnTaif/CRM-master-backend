using System.Security.Claims;
using System.Text.Json.Nodes;
using MasterCRM.Application.Services.Auth.ExternalAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Auth;

[ApiController]
[Route("auth")]
public class ExternalAuthController(IVkAuthService vkAuthService) : ControllerBase
{
    /// <summary>
    /// Logs in the user using VK account or creates a new account if it doesn't exist
    /// </summary>
    [HttpGet("externalLogin/vk")]
    [ProducesResponseType(typeof(VkLoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VkLoginResponse>> VkGetLogin()
    {
        var payload = HttpContext.Request.Query["payload"].ToString();

        if (string.IsNullOrEmpty(payload))
            return BadRequest("Payload parameter is null or empty.");

        var response = await vkAuthService.LoginWithPayloadAsync(payload);

        if (response == null)
            return BadRequest("VK token exchange failed");

        return Ok(response);
    }
    
    [HttpPost("externalLogin/vk")]
    public async Task<IActionResult> VkIdLogin(VkLoginRequest request)
    {
        var response = await vkAuthService.LoginWithRequestAsync(request);
        
        if (response == null)
            return BadRequest("VK token exchange failed");

        return Ok(response);
    }
    
    /// <summary>
    /// Links VK account to the current user
    /// </summary>
    /// <returns>VK id of the linked account</returns>
    [Authorize]
    [HttpPost("link/vk")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> LinkVkAccount(VkLoginRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        var vkId = await vkAuthService.LinkAsync(userId, request);

        if (vkId == null)
            return BadRequest("VK ID is already used by another user");
        
        return Ok(vkId);
    }
}

