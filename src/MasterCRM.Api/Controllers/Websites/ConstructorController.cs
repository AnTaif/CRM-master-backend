using System.Security.Claims;
using MasterCRM.Application.Services.Websites.Constructor;
using MasterCRM.Application.Services.Websites.Constructor.Requests;
using MasterCRM.Application.Services.Websites.Constructor.Responses;
using MasterCRM.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Websites;

[ApiController]
[Authorize]
[Route("website/constructor")]
public class ConstructorController(IConstructorService constructorService) : ControllerBase
{
    [HttpGet("global-styles")]
    public async Task<ActionResult<GlobalStylesDto>> GetGlobalStyles()
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var response = await constructorService.GetGlobalStylesAsync(masterId);

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
    public async Task<IActionResult> ChangeGlobalStyles(ChangeGlobalStylesRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var response = await constructorService.ChangeGlobalStylesAsync(masterId, request);

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
    
    [HttpGet("blocks/main")]
    public async Task<ActionResult<IEnumerable<BlockDto>>> GetMainSection()
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var response = await constructorService.GetMainSectionAsync(masterId);

            return Ok(response);
        }
        catch (ForbidException)
        {
            return StatusCode(403);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("blocks/{id}")]
    public async Task<ActionResult<BlockDto>> ChangeBlock([FromRoute] Guid id, ChangeBlockRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var response = await constructorService.ChangeBlockAsync(masterId, id, request);

            if (response == null)
                return NotFound("Block bot found");
            
            return Ok(response);
        }
        catch (ForbidException)
        {
            return StatusCode(403);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
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