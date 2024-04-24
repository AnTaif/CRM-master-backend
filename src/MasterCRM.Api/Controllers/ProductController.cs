using System.Security.Claims;
using MasterCRM.Application.Services.Product;
using MasterCRM.Application.Services.Product.Requests;
using MasterCRM.Application.Services.Product.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers;

[ApiController]
[Route("products")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetProductResponse>>> GetProducts()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (userId == null)
            return Forbid();
        
        var response = await productService.GetAllProductsAsync(userId);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetProductResponse>> Get([FromRoute] Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return Forbid();

        var response = await productService.GetProductByIdAsync(id);

        if (response == null)
            return NotFound();

        if (userId != response.UserId)
            return Forbid();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (userId == null)
            return Forbid();

        var response = await productService.CreateAsync(userId, request);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Change(Guid id, ChangeProductRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (userId == null)
            return Forbid();
        
        var product = await productService.GetProductByIdAsync(id);

        if (product == null)
            return NotFound();

        if (userId != product.UserId)
            return Forbid();

        var response = await productService.ChangeAsync(id, request);

        if (response == null)
            return BadRequest();

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (userId == null)
            return Forbid();
        
        var product = await productService.GetProductByIdAsync(id);

        if (product == null)
            return NotFound();

        if (userId != product.UserId)
            return Forbid();

        var success = await productService.TryDeleteAsync(id);

        if (!success)
            return BadRequest();

        return NoContent();
    }
}