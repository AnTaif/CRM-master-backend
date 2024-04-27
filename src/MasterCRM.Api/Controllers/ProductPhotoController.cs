using System.Security.Claims;
using MasterCRM.Application.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers;

[ApiController]
[Authorize]
[Route("products/{productId}/photos")]
public class ProductPhotoController(IProductService productService) : ControllerBase
{
    private readonly string[] allowedExtensions = {".jpg", ".jpeg", ".png"};
    
    [HttpPost]
    public async Task<IActionResult> AddPhotosToProduct([FromRoute] Guid productId, IEnumerable<IFormFile> formFiles)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        var product = await productService.GetProductByIdAsync(productId);

        if (product == null)
            return NotFound();

        if (userId != product.UserId)
            return Forbid();

        var fileRequests = formFiles.Select(formFile =>
        {
            var fileExtension = Path.GetExtension(formFile.FileName);
            
            var fileStream = formFile.OpenReadStream();
            return new UploadPhotoRequest(fileStream, fileExtension);
        }).ToList();

        var usedAllowedExtensions = fileRequests.All(file => allowedExtensions.Contains(file.Extension));

        if (!usedAllowedExtensions)
            return BadRequest("Invalid file extension. Allowed extensions: .jpg, .jpeg, .png");
        
        var productPhotoDtos = await productService.AddPhotosToProductAsync(productId, fileRequests);

        if (productPhotoDtos == null)
            return BadRequest();
        
        return Ok(productPhotoDtos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhoto([FromRoute] Guid productId, [FromRoute] Guid id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        var product = await productService.GetProductByIdAsync(productId);

        if (product == null)
            return NotFound();

        if (userId != product.UserId)
            return Forbid();

        var success = await productService.TryDeletePhotoAsync(productId, id);

        if (!success)
            return BadRequest();

        return Ok();
    }
}