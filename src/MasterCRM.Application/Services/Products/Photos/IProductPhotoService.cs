using MasterCRM.Application.Services.Products.Photos.Requests;
using MasterCRM.Application.Services.Products.Photos.Responses;

namespace MasterCRM.Application.Services.Products.Photos;

public interface IProductPhotoService
{
    public Task<IEnumerable<ProductPhotoDto>?> AddPhotosToProductAsync(string userId, Guid productId, IEnumerable<UploadPhotoRequest> request);

    public Task<IEnumerable<ProductPhotoDto>?> UpdateRangeAsync(string userId, Guid productId, IEnumerable<UpdateProductPhotosRequest> requests);
    
    public Task<bool> TryDeletePhotoAsync(string userId, Guid productId, Guid photoId);
}