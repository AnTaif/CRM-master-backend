using System.Security.Claims;
using MasterCRM.Application.Services.Products;
using MasterCRM.Application.Services.Websites.PublicWebsite;
using MasterCRM.Application.Services.Websites.PublicWebsite.Requests;
using MasterCRM.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Websites;

[ApiController]
[Authorize]
[Route("website")]
public class WebsiteController(IWebsiteService websiteService, IProductService productService) : ControllerBase
{
    [HttpGet("info")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var response = await websiteService.GetWebsiteInfo(masterId);

            if (response == null)
                return NotFound();

            return Ok(response);
        }
        catch (ForbidException)
        {
            return StatusCode(403);
        }
    }
    
    [HttpPut("info")]
    public async Task<IActionResult> ChangeInfo(ChangeWebsiteInfoRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var response = await websiteService.ChangeWebsiteInfoAsync(masterId, request);

            if (response == null)
                return NotFound();
            
            return Ok();
        }
        catch (ForbidException)
        {
            return StatusCode(403);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateWebsiteRequest request)
    {
        var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var response = await websiteService.CreateAsync(masterId, request);

        if (response == null)
            return BadRequest();
        
        return Ok(response);
    }

    [HttpPost("select-template")]
    public async Task<IActionResult> SelectTemplate(SelectTemplateRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var response = await websiteService.SelectTemplateAsync(masterId, request);

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

    [AllowAnonymous]
    [HttpGet("{websiteId}/products")]
    public async Task<IActionResult> GetVisibleProducts([FromRoute] Guid websiteId)
    {
        try
        {
            var response = await productService.GetWebsiteProductsAsync(websiteId);

            return Ok(response);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}