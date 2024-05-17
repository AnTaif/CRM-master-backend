using MasterCRM.Application.Services.Orders.Products;
using MasterCRM.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories.Orders;

public class OrderProductRepository(CrmDbContext context) : IOrderProductRepository
{
    private DbSet<OrderProduct> dbSet => context.OrderProducts;

    public async Task<OrderProduct?> GetByIdAsync(Guid id) => 
        await dbSet
            .Include(orderProduct => orderProduct.Product)
            .ThenInclude(product => product.Photos)
            .FirstOrDefaultAsync(orderProduct => orderProduct.Id == id);

    public async Task CreateAsync(OrderProduct orderProduct) => await dbSet.AddAsync(orderProduct);
    
    public void Delete(OrderProduct orderProduct) => dbSet.Remove(orderProduct);
    
    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}