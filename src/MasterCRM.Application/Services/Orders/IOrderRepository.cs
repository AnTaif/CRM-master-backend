using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.Services.Orders;

public interface IOrderRepository
{
    public Task<IEnumerable<Order>> GetActiveByMasterAsync(string masterId);
    
    public Task<IEnumerable<Order>> GetInactiveByMasterAsync(string masterId);
    
    public Task<Order> GetByIdAsync(Guid id);
    
    public Task CreateAsync(Order order);
    
    public Task UpdateAsync(Order order);
    
    public Task DeleteAsync(Order order);
    
    public Task SaveChangesAsync();
}