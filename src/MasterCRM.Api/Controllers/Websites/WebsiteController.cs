using System.Security.Claims;
using MasterCRM.Application.Services.Orders;
using MasterCRM.Application.Services.Orders.Requests;
using MasterCRM.Application.Services.Products;
using MasterCRM.Application.Services.Products.Responses;
using MasterCRM.Application.Services.User;
using MasterCRM.Application.Services.User.Responses;
using MasterCRM.Application.Services.Websites.PublicWebsite;
using MasterCRM.Application.Services.Websites.PublicWebsite.Requests;
using MasterCRM.Application.Services.Websites.PublicWebsite.Responses;
using MasterCRM.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Websites;

[ApiController]
[Authorize]
[Route("website")]
public class WebsiteController(IWebsiteService websiteService, IProductService productService,
    IUserService userService, IOrderService orderService) : ControllerBase
{
    [HttpGet("info")]
    [ProducesResponseType(typeof(WebsiteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var response = await websiteService.GetWebsiteInfo(masterId);

            if (response == null)
                return NotFound("Website not found");

            return Ok(response);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPut("info")]
    [ProducesResponseType(typeof(WebsiteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ChangeInfo(ChangeWebsiteInfoRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var response = await websiteService.ChangeWebsiteInfoAsync(masterId, request);

            if (response == null)
                return NotFound("Website not found");
            
            return Ok(response);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(WebsiteDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateWebsiteRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var response = await websiteService.CreateAsync(masterId, request);

            if (response == null)
                return BadRequest("Master already have website");

            return CreatedAtAction(nameof(Create), response);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("select-template")]
    [ProducesResponseType(typeof(WebsiteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SelectTemplate(SelectTemplateRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var response = await websiteService.SelectTemplateAsync(masterId, request);

            if (response == null)
                return NotFound("Website not found");
            
            return Ok(response);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [AllowAnonymous]
    [HttpGet("{address}/products")]
    [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVisibleProducts([FromRoute] string address)
    {
        try
        {
            var response = await productService.GetWebsiteProductsAsync(address);

            return Ok(response);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [AllowAnonymous]
    [HttpGet("{address}/master-info")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMasterInfo([FromRoute] string address)
    {
        try
        {
            var masterDto = await userService.GetInfoByWebsiteAsync(address);

            if (masterDto == null)
                return NotFound("Master not found");

            return Ok(masterDto);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [AllowAnonymous]
    [HttpPost("{address}/orders")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateOrder([FromRoute] string address, CreateWebsiteOrderRequest request)
    {
        try
        {
            await orderService.CreateOrderForWebsiteAsync(address, request);
            return CreatedAtAction(nameof(CreateOrder), null);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ForbidException e)
        {
            return StatusCode(StatusCodes.Status403Forbidden, e.Message);
        }
    }
}