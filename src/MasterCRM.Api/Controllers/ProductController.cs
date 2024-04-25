using System.Security.Claims;
using MasterCRM.Application.Services.Product;
using MasterCRM.Application.Services.Product.Dto;
using MasterCRM.Application.Services.Product.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers;

[ApiController]
[Authorize]
[Route("products")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        var response = await productService.GetAllProductsAsync(userId);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get([FromRoute] Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var response = await productService.GetProductByIdAsync(id);

        if (response == null)
            return NotFound();

        if (userId != response.UserId)
            return Forbid();

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromForm]CreateProductRequest request, IEnumerable<IFormFile> formFiles)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var fileRequests = formFiles.Select(formFile =>
        {
            var fileExtension = Path.GetExtension(formFile.FileName);
            var fileStream = formFile.OpenReadStream();
            return new UploadPhotoRequest(fileStream, fileExtension);
        });
        
        var response = await productService.CreateAsync(userId, request, fileRequests);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Change(Guid id, ChangeProductRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
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
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
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