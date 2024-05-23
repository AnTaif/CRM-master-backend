using System.Security.Claims;
using MasterCRM.Application.Services.User;
using MasterCRM.Application.Services.User.Requests;
using MasterCRM.Application.Services.User.Responses;
using MasterCRM.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = "BearerToken")]
[Route("user")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserDto>> Get()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        var response = await userService.GetInfoAsync(userId);

        if (response == null)
            return StatusCode(StatusCodes.Status401Unauthorized);

        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> ChangeUserInfo(ChangeUserInfoRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var userInfoResponse = await userService.ChangeInfoAsync(userId, request);

        if (userInfoResponse == null)
            return StatusCode(StatusCodes.Status401Unauthorized);

        return Ok(userInfoResponse);
    }
    
    [HttpPatch("password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Dictionary<string, string[]>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> ChangeUserPassword(ChangePasswordRequest request)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var result = await userService.TryChangePasswordAsync(userId, request);

            if (result.Succeeded) 
                return NoContent();
            
            var errors = result.Errors.ToDictionary(e => e.Code, e => new[] { e.Description });
            return BadRequest(errors);
        }
        catch (NotFoundException e)
        {
            return StatusCode(StatusCodes.Status401Unauthorized); // User not found = Unauthorized
        }
    }
}