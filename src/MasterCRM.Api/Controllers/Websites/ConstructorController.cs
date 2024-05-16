using System.Security.Claims;
using MasterCRM.Application.Services.Websites.Constructor;
using MasterCRM.Domain.Exceptions;
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
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var response = await constructorService.GetGlobalStylesAsync(masterId, websiteId);

            if (response == null)
                return NotFound("GlobalStyles not found");

            return Ok(response);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ForbidException)
        {
            return StatusCode(403);
        }
    }

    [HttpPut("global-styles")]
    public async Task<IActionResult> ChangeGlobalStyles([FromRoute] Guid websiteId, ChangeGlobalStylesRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var response = await constructorService.ChangeGlobalStylesAsync(masterId, websiteId, request);

            if (response == null)
                return NotFound("GlobalStyle not found");

            return Ok(response);
        }
        catch (NotFoundException)
        {
            return NotFound("Website not found");
        }
        catch (ForbidException)
        {
            return StatusCode(403);
        }
    }
    
    // [HttpGet("main")]
    // public async Task GetMainSection()
    // {
    //     throw new NotImplementedException();
    // }
    
    // [HttpGet("order")]
    // public async Task GetOrderRegistrationSection()
    // {
    //     throw new NotImplementedException();
    // }
    
    // [HttpGet("product")]
    // public async Task GetProductCardSection()
    // {
    //     throw new NotImplementedException();
    // }
}