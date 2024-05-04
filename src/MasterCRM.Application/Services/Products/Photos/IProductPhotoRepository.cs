using MasterCRM.Domain.Entities.Products;

namespace MasterCRM.Application.Services.Products.Photos;

public interface IProductPhotoRepository
{
    public Task<ProductPhoto?> GetByIdAsync(Guid id);

    public Task CreateAsync(ProductPhoto productPhoto);
    
    public Task SaveChangesAsync();
}