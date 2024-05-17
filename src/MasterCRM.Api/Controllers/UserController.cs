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
    public async Task<ActionResult<UserDto>> Get()
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

        var userInfoResponse = await userService.ChangeInfoAsync(userId, request);

        if (userInfoResponse == null)
            return BadRequest();

        return Ok(userInfoResponse);
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