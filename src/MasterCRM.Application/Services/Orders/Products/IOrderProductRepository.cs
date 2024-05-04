using MasterCRM.Domain.Entities.Orders;

namespace MasterCRM.Application.Services.Orders.Products;

public interface IOrderProductRepository
{
    public Task<OrderProduct?> GetByIdAsync(Guid id);
    
    public Task CreateAsync(OrderProduct orderProduct);
    
    public void Delete(OrderProduct orderProduct);
    
    public Task SaveChangesAsync();
}