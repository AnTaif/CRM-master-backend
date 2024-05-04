using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Products.Dto;
using MasterCRM.Application.Services.Products.Requests;
using MasterCRM.Domain.Entities.Products;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Application.Services.Products.Photos;

public class ProductPhotoService( 
    IProductRepository productRepository,
    IFileStorage fileStorage, 
    IProductPhotoRepository productPhotoRepository) : IProductPhotoService
{
    public async Task<IEnumerable<ProductPhotoDto>?> AddPhotosToProductAsync(Guid productId, IEnumerable<UploadPhotoRequest> request)
    {
        var product = await productRepository.GetByIdAsync(productId);

        if (product == null)
            return null;

        var photos = new List<ProductPhoto>();
        foreach (var uploadRequest in request)
        {
            var fileId = Guid.NewGuid();
            var fileName = fileId + uploadRequest.Extension;
            var url = await fileStorage.UploadAsync(uploadRequest.PhotoStream, fileName);

            var photo = new ProductPhoto
            {
                Id = fileId,
                ProductId = productId,
                Order = (short)product.Photos.Count,
                Url = url,
                Extension = uploadRequest.Extension
            };
            await productPhotoRepository.CreateAsync(photo);
            photos.Add(photo);
        }

        await productRepository.SaveChangesAsync();
        return photos.Select(photo => photo.ToDto());
    }

    public async Task<IEnumerable<ProductPhotoDto>> UpdateRangeAsync(Guid productId, IEnumerable<UpdateProductPhotosRequest> requests)
    {
        var product = await productRepository.GetByIdAsync(productId);

        if (product == null)
            throw new Exception("Product not found");

        var photos = new List<ProductPhoto>();
        foreach (var request in requests)
        {
            var productPhoto = await productPhotoRepository.GetByIdAsync(request.Id);

            if (productPhoto == null)
                throw new Exception("ProductPhoto not found");
            
            productPhoto.Update(request.Order, null);
            photos.Add(productPhoto);
        }

        await productRepository.SaveChangesAsync();

        return photos.Select(photo => photo.ToDto());
    }
    
    public async Task<bool> TryDeletePhotoAsync(Guid productId, Guid photoId)
    {
        var product = await productRepository.GetByIdAsync(productId);

        var photo = product?.Photos.FirstOrDefault(photo => photo.Id == photoId);
        
        if (photo == null)
            return false;

        product!.Photos.Remove(photo);
        await productRepository.SaveChangesAsync();
        return fileStorage.TryDelete(photo.Url);
    }
}