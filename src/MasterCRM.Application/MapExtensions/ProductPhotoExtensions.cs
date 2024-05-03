using MasterCRM.Application.Services.Products.Dto;
using MasterCRM.Domain.Entities.Products;

namespace MasterCRM.Application.MapExtensions;

public static class ProductPhotoExtensions
{
    public static ProductPhotoDto ToDto(this ProductPhoto productPhoto)
    {
        return new ProductPhotoDto(productPhoto.Id, productPhoto.Url);
    }
}