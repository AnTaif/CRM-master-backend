using System.Security.Claims;
using MasterCRM.Application.Services.Products;
using MasterCRM.Application.Services.Products.Dto;
using MasterCRM.Application.Services.Products.Requests;
using MasterCRM.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Products;

[ApiController]
[Authorize]
[Route("products")]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly string[] allowedExtensions = {".jpg", ".jpeg", ".png"};
    
    //TODO: add isVisible parameter
    /// <summary>
    /// Returns all products of the current authorized user
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        var response = await productService.GetUserProductsAsync(userId);

        return Ok(response);
    }

    /// <summary>
    /// Returns all products of the specified user
    /// </summary>
    [HttpGet("user/{userId}")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByUser([FromRoute] string userId)
    {
        var response = await productService.GetUserProductsAsync(userId);
        
        return Ok(response);
    }

    /// <summary>
    /// Get product by id
    /// </summary>
    /// <returns>Product dto model</returns>
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<ProductDto>> Get([FromRoute] Guid id)
    {
        var productDto = await productService.GetProductByIdAsync(id);

        if (productDto == null)
            return NotFound();

        return Ok(productDto);
    }

    /// <summary>
    /// Create a new product
    /// </summary>
    /// <param name="request">Create product request</param>
    /// <param name="formFiles">Product photos</param>
    /// <returns>Product dto model</returns>
    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromForm]CreateProductRequest request, IEnumerable<IFormFile> formFiles)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var fileRequests = formFiles.Select(formFile =>
        {
            var fileExtension = Path.GetExtension(formFile.FileName);
            var fileStream = formFile.OpenReadStream();
            return new UploadPhotoRequest(fileStream, fileExtension);
        }).ToList();
        
        var usedAllowedExtensions = fileRequests.All(file => allowedExtensions.Contains(file.Extension));

        if (!usedAllowedExtensions)
            return BadRequest("Invalid file extension. Allowed extensions: .jpg, .jpeg, .png");
        
        var productDto = await productService.CreateAsync(userId, request, fileRequests);

        return Ok(productDto);
    }

    /// <summary>
    /// Change product by id
    /// </summary>
    /// <returns>Product dto model</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDto>> Change([FromRoute] Guid id, ChangeProductRequest request)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var productDto = await productService.ChangeAsync(userId, id, request);

            if (productDto == null)
                return NotFound();

            return Ok(productDto);
        }
        catch (ForbidException)
        {
            return Forbid();
        }
    }

    [HttpPatch("{id}/toggle-visibility")]
    public async Task<IActionResult> ToggleVisibility([FromRoute] Guid id)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var productDto = await productService.ToggleVisibility(masterId, id);

            if (productDto == null)
                return NotFound();

            return Ok(productDto);
        }
        catch (ForbidException)
        {
            return Forbid();
        }
    }

    /// <summary>
    /// Delete product by id
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
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