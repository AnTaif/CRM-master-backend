using MasterCRM.Application.Interfaces;
using MasterCRM.Application.Services.User.Requests;
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
        var res = await userService.RegisterAsync(request);

        if (!res.Succeeded)
            return BadRequest();

        return NoContent();
    }
    
    [HttpPost("login")]
    [ProducesResponseType(typeof(SignInResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var res = await userService.LoginAsync(request);

        if (!res.Succeeded)
            return BadRequest();

        return NoContent();
    }
}