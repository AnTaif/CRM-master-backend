using MasterCRM.Application.Services.Products.Photos;
using MasterCRM.Domain.Entities.Products;
using MasterCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories.Products;

public class ProductPhotoRepository(CrmDbContext context) : IProductPhotoRepository
{
    private DbSet<ProductPhoto> dbSet => context.ProductPhotos;

    public async Task<ProductPhoto?> GetByIdAsync(Guid id) => await dbSet.FindAsync(id);
    
    public async Task CreateAsync(ProductPhoto productPhoto) => await dbSet.AddAsync(productPhoto);
    
    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}