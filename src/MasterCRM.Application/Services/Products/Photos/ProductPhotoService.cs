using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Products.Photos.Requests;
using MasterCRM.Application.Services.Products.Photos.Responses;
using MasterCRM.Domain.Entities.Products;
using MasterCRM.Domain.Exceptions;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Application.Services.Products.Photos;

public class ProductPhotoService( 
    IProductRepository productRepository,
    IFileStorage fileStorage, 
    IProductPhotoRepository productPhotoRepository) : IProductPhotoService
{
    public async Task<IEnumerable<ProductPhotoDto>?> AddPhotosToProductAsync(string userId, Guid productId, IEnumerable<UploadPhotoRequest> request)
    {
        var product = await productRepository.GetByIdAsync(productId);

        if (product == null)
            return null;

        if (product.MasterId != userId)
            throw new ForbidException("Current user is not the owner of the product");

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

    public async Task<IEnumerable<ProductPhotoDto>?> UpdateRangeAsync(string userId, Guid productId, IEnumerable<UpdateProductPhotosRequest> requests)
    {
        var product = await productRepository.GetByIdAsync(productId);

        if (product == null)
            return null;
        
        if (product.MasterId != userId)
            throw new ForbidException("Current user is not the owner of the product");

        var photos = new List<ProductPhoto>();
        foreach (var request in requests)
        {
            var productPhoto = await productPhotoRepository.GetByIdAsync(request.Id);

            if (productPhoto == null)
                throw new NotFoundException("ProductPhoto not found");
            
            productPhoto.Update(request.Order, null);
            photos.Add(productPhoto);
        }

        await productRepository.SaveChangesAsync();

        return photos.Select(photo => photo.ToDto());
    }
    
    public async Task<bool> TryDeletePhotoAsync(string userId, Guid productId, Guid photoId)
    {
        var product = await productRepository.GetByIdAsync(productId);

        if (product == null)
            return false;
        
        if (product.MasterId != userId)
            throw new ForbidException("Current user is not the owner of the product");

        var photo = product.Photos.FirstOrDefault(photo => photo.Id == photoId);
        
        if (photo == null)
            return true;

        product.Photos.Remove(photo);
        await productRepository.SaveChangesAsync();
        return fileStorage.TryDelete(photo.Url);
    }
}