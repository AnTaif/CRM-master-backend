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
    [HttpPost("externalLogin/vk")]
    public async Task<ActionResult<VkLoginResponse>> VkLogin()
    {
        var payload = HttpContext.Request.Query["payload"].ToString();

        if (string.IsNullOrEmpty(payload))
            return BadRequest("Payload parameter is null or empty.");

        var response = await vkAuthService.LoginAsync(payload);

        return Ok(response);
    }
    
    /// <summary>
    /// Logs in the user using VK account or creates a new account if it doesn't exist
    /// </summary>
    [HttpGet("externalLogin/vk")]
    public async Task<ActionResult<VkLoginResponse>> VkGetLogin()
    {
        var payload = HttpContext.Request.Query["payload"].ToString();

        if (string.IsNullOrEmpty(payload))
            return BadRequest("Payload parameter is null or empty.");

        var response = await vkAuthService.LoginAsync(payload);

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
}