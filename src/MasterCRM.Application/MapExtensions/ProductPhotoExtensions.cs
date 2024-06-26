using MasterCRM.Application.Services.Products.Photos.Responses;
using MasterCRM.Domain.Entities.Products;

namespace MasterCRM.Application.MapExtensions;

public static class ProductPhotoExtensions
{
    public static ProductPhotoDto ToDto(this ProductPhoto productPhoto)
    {
        return new ProductPhotoDto(productPhoto.Id, productPhoto.Url, productPhoto.Order);
    }
}