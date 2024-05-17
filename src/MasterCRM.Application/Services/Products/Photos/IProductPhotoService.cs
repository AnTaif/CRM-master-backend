using MasterCRM.Application.Services.Products.Photos.Requests;
using MasterCRM.Application.Services.Products.Photos.Responses;

namespace MasterCRM.Application.Services.Products.Photos;

public interface IProductPhotoService
{
    public Task<IEnumerable<ProductPhotoDto>?> AddPhotosToProductAsync(Guid productId, IEnumerable<UploadPhotoRequest> request);

    public Task<IEnumerable<ProductPhotoDto>> UpdateRangeAsync(Guid productId, IEnumerable<UpdateProductPhotosRequest> requests);
    
    public Task<bool> TryDeletePhotoAsync(Guid productId, Guid photoId);
}