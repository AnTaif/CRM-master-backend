using System.Security.Claims;
using MasterCRM.Application.Services.Websites.Constructor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Websites;

[ApiController]
[Authorize]
[Route("websites/{websiteId}/constructor")]
public class ConstructorController(IConstructorService constructorService) : ControllerBase
{
    [HttpGet("global-styles")]
    public async Task<ActionResult<IEnumerable<StyleDto>>> GetGlobalStyles([FromRoute] Guid websiteId)
    {
        var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var response = await constructorService.GetGlobalStylesAsync(masterId, websiteId);

        return Ok(response);
    }

    [HttpPut("global-styles")]
    public async Task<IActionResult> ChangeGlobalStyles([FromRoute] Guid websiteId)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("main")]
    public async Task GetMainSection()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("order")]
    public async Task GetOrderRegistrationSection()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("product")]
    public async Task GetProductCardSection()
    {
        throw new NotImplementedException();
    }
}