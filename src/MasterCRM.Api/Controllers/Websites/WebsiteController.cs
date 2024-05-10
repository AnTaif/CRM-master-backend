using System.Security.Claims;
using MasterCRM.Application.Services.Websites.PublicWebsite;
using MasterCRM.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Websites;

[ApiController]
[Authorize]
[Route("websites")]
public class WebsiteController(IWebsiteService websiteService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(string title)
    {
        var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var response = await websiteService.CreateAsync(masterId, title);

        if (response == null)
            return BadRequest();
        
        return Ok(response);
    }

    [HttpPost("{websiteId}/template")]
    public async Task<IActionResult> SelectTemplate([FromRoute] Guid websiteId, int templateId)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var response = await websiteService.SelectTemplateAsync(masterId, websiteId, templateId);

            if (response == null)
                return NotFound("Website not found");
            
            return Ok();
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
    
    [HttpPut("{websiteId}")]
    public async Task<IActionResult> ChangeInfo([FromRoute] Guid websiteId, ChangeWebsiteInfoRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var response = await websiteService.ChangeWebsiteInfoAsync(masterId, websiteId, request);

            if (response == null)
                return NotFound();
            
            return Ok();
        }
        catch (ForbidException)
        {
            return StatusCode(403);
        }
    }
}