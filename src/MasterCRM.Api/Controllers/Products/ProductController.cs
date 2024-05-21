using System.Security.Claims;
using MasterCRM.Application.Services.Products;
using MasterCRM.Application.Services.Products.Photos.Requests;
using MasterCRM.Application.Services.Products.Requests;
using MasterCRM.Application.Services.Products.Responses;
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
    
    /// <summary>
    /// Returns all products of the current authorized user
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        var response = await productService.GetUserProductsAsync(userId);

        return Ok(response);
    }

    /// <summary>
    /// Get product by id
    /// </summary>
    /// <returns>Product dto model</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<ProductDto>> Get([FromRoute] Guid id)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            
            var productDto = await productService.GetProductByIdAsync(userId, id);

            if (productDto == null)
                return NotFound("Product not found");

            return Ok(productDto);
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }

    /// <summary>
    /// Create a new product
    /// </summary>
    /// <param name="request">Create product request</param>
    /// <param name="formFiles">Product photos</param>
    /// <returns>Product dto model</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
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

        return CreatedAtAction(nameof(Create), productDto);
    }

    /// <summary>
    /// Change product by id
    /// </summary>
    /// <returns>Product dto model</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<ProductDto>> Change([FromRoute] Guid id, ChangeProductRequest request)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var productDto = await productService.ChangeAsync(userId, id, request);

            if (productDto == null)
                return NotFound("Product not found");

            return Ok(productDto);
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }

    [HttpPatch("{id}/toggle-visibility")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ToggleVisibility([FromRoute] Guid id)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var productDto = await productService.ToggleVisibility(masterId, id);

            if (productDto == null)
                return NotFound("Product not found");

            return Ok(productDto);
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }

    /// <summary>
    /// Delete product by id
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var success = await productService.TryDeleteAsync(userId, id);

            if (!success)
                return NotFound("Product not found");

            return NoContent();
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }
}