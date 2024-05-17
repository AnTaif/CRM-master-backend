using MasterCRM.Application.Services.Products.Responses;
using MasterCRM.Domain.Entities.Products;

namespace MasterCRM.Application.MapExtensions;

public static class ProductExtensions
{
    public static ProductDto ToDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            UserId = product.MasterId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Material = product.Material.ConvertToString(),
            Dimensions = product.Dimensions ?? "",
            IsVisible = product.IsVisible,
            Photos = product.Photos.OrderBy(photo => photo.Order).Select(productPhoto => productPhoto.ToDto()).ToList()
        };
    }
}