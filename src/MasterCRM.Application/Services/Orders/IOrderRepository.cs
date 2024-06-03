using System.Linq.Expressions;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;

namespace MasterCRM.Application.Services.Orders;

public interface IOrderRepository
{
    public Task<IEnumerable<Order>> GetAllByMasterAsync(string masterId);
    
    public Task<IEnumerable<Order>> GetWithStageByMasterAsync(string masterId, short stageTab);
    
    public Task<Order?> GetByIdAsync(Guid id);
    
    public Task CreateAsync(Order order);
    
    public void Update(Order order);
    
    public void Delete(Order order);
    
    public Task SaveChangesAsync();
}