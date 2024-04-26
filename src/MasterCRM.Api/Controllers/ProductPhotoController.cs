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
    [HttpPost]
    public async Task<IActionResult> AddPhotosToProduct(Guid productId, IEnumerable<IFormFile> formFiles)
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
        });
        
        // Add photo to product
        var response = await productService.AddPhotosToProductAsync(productId, fileRequests);

        return Ok(response);
    }

    [HttpDelete("{photoId}")]
    public async Task<IActionResult> DeletePhoto(Guid productId, Guid photoId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        var product = await productService.GetProductByIdAsync(productId);

        if (product == null)
            return NotFound();

        if (userId != product.UserId)
            return Forbid();

        var response = await productService.TryDeletePhotoAsync(productId, photoId);

        if (!response)
            return BadRequest();

        return Ok();
    }
}