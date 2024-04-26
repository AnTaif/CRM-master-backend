using System.Security.Claims;
using MasterCRM.Application.Services.User;
using MasterCRM.Application.Services.User.Requests;
using MasterCRM.Application.Services.User.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers;

[Authorize]
[ApiController]
[Route("user")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetUserInfoResponse>> Get()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return Forbid();
        
        var response = await userService.GetInfoAsync(userId);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> ChangeUserInfo(ChangeUserInfoRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (userId == null)
            return Forbid();

        var success = await userService.TryChangeInfoAsync(userId, request);

        if (!success)
            return BadRequest();

        return NoContent();
    }
    
    [HttpPut("/password")]
    public async Task<IActionResult> ChangeUserPassword(ChangePasswordRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (userId == null)
            return Forbid();

        var success = await userService.TryChangePasswordAsync(userId, request);

        if (!success)
            return BadRequest();

        return NoContent();
    }
}