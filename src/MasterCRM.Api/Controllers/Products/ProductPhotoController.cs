using System.Security.Claims;
using MasterCRM.Application.Services.Products;
using MasterCRM.Application.Services.Products.Dto;
using MasterCRM.Application.Services.Products.Photos;
using MasterCRM.Application.Services.Products.Requests;
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
    public async Task<IActionResult> AddPhotosToProduct([FromRoute] Guid productId, IEnumerable<IFormFile> formFiles)
    {
        //TODO: protect services by another users
        //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var fileRequests = formFiles.Select(formFile =>
        {
            var fileExtension = Path.GetExtension(formFile.FileName);
            
            var fileStream = formFile.OpenReadStream();
            return new UploadPhotoRequest(fileStream, fileExtension);
        }).ToList();

        var usedAllowedExtensions = fileRequests.All(file => allowedExtensions.Contains(file.Extension));

        if (!usedAllowedExtensions)
            return BadRequest("Invalid file extension. Allowed extensions: .jpg, .jpeg, .png");
        
        var productPhotoDtos = await productPhotoService.AddPhotosToProductAsync(productId, fileRequests);

        if (productPhotoDtos == null)
            return BadRequest();
        
        return CreatedAtAction(nameof(AddPhotosToProduct), productPhotoDtos);
    }

    [HttpPut]
    public async Task<ActionResult<IEnumerable<ProductPhotoDto>>> Update([FromRoute] Guid productId, IEnumerable<UpdateProductPhotosRequest> requests)
    {
        //TODO: добавить обновление фотографии?
        var dtos = await productPhotoService.UpdateRangeAsync(productId, requests);

        return Ok(dtos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhoto([FromRoute] Guid productId, [FromRoute] Guid id)
    {
        //TODO: protect services by another users
        //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var success = await productPhotoService.TryDeletePhotoAsync(productId, id);

        if (!success)
            return BadRequest();

        return Ok();
    }
}