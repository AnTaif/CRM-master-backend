using MasterCRM.Application.Services.User;
using MasterCRM.Application.Services.User.Requests;
using MasterCRM.Application.Services.User.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = MasterCRM.Application.Services.User.Requests.LoginRequest;
using SignInResult = Microsoft.AspNetCore.Mvc.SignInResult;

namespace MasterCRM.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IUserService userService) : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var result = await userService.RegisterAsync(request);

        if (!result.Succeeded)
            return BadRequest();

        return NoContent();
    }
    
    [HttpPost("login")]
    [ProducesResponseType(typeof(SignInResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await userService.LoginAsync(request);

        if (!result.Succeeded)
            return BadRequest();

        return NoContent();
    }

    [HttpGet("externalLogin")]
    public async Task<ActionResult<VkLoginResponse>> ExternalLogin()
    {
        var payloadEncoded = HttpContext.Request.Query["payload"].ToString();

        if (string.IsNullOrEmpty(payloadEncoded))
            return BadRequest("Payload parameter not found or empty.");

        var response = await userService.VkLoginAsync(payloadEncoded);

        return Ok(response);
    }
}