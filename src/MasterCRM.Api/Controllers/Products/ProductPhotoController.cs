using System.Security.Claims;
using MasterCRM.Application.Services.Products.Photos;
using MasterCRM.Application.Services.Products.Photos.Requests;
using MasterCRM.Application.Services.Products.Photos.Responses;
using MasterCRM.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Products;

[ApiController]
[Authorize]
[Route("products/{productId}/photos")]
public class ProductPhotoController(IProductPhotoService productPhotoService) : ControllerBase
{
    private readonly string[] allowedExtensions = {".jpg", ".jpeg", ".png"};
    
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<ProductPhotoDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AddPhotosToProduct([FromRoute] Guid productId, IEnumerable<IFormFile> formFiles)
    {
        try
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
            
            var productPhotoDtos = await productPhotoService.AddPhotosToProductAsync(userId, productId, fileRequests);

            if (productPhotoDtos == null)
                return NotFound("Product not found");
            
            return CreatedAtAction(nameof(AddPhotosToProduct), productPhotoDtos);
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }

    [HttpPut]
    [ProducesResponseType(typeof(IEnumerable<ProductPhotoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<IEnumerable<ProductPhotoDto>>> Update([FromRoute] Guid productId, IEnumerable<UpdateProductPhotosRequest> requests)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            
            var dtos = await productPhotoService.UpdateRangeAsync(userId, productId, requests);

            if (dtos == null)
                return NotFound("Product not found");
            
            return Ok(dtos);
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeletePhoto([FromRoute] Guid productId, [FromRoute] Guid id)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var success = await productPhotoService.TryDeletePhotoAsync(userId, productId, id);

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