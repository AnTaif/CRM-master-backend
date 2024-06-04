using System.Linq.Expressions;
using MasterCRM.Application.Services.Orders;
using MasterCRM.Domain.Entities.Orders;
using MasterCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories.Orders;

public class OrderRepository(CrmDbContext context) : IOrderRepository
{
    private DbSet<Order> dbSet => context.Orders;

    public async Task<IEnumerable<Order>> GetAllByMasterAsync(string masterId) =>
        await dbSet
            .Include(order => order.Stage)
            .Include(order => order.Client)
            .Where(order => order.MasterId == masterId)
            .ToListAsync();

    public async Task<IEnumerable<Order>> GetWithStageByMasterAsync(string masterId, short stageTab) =>
        await dbSet
            .Include(order => order.Stage)
            .Include(order => order.Client)
            .Where(order => order.MasterId == masterId && order.Stage.Order == stageTab)
            .ToListAsync();

    public async Task<Order?> GetByIdAsync(Guid id) =>
        await dbSet
            .Include(order => order.Stage)
            .Include(order => order.Master)
            .Include(order => order.Client)
                .ThenInclude(client => client.Orders)
            .Include(order => order.OrderProducts)
                .ThenInclude(orderProduct => orderProduct.Product)
                .ThenInclude(product => product.Photos)
            .FirstOrDefaultAsync(e => e.Id == id);

    public async Task CreateAsync(Order order) => await dbSet.AddAsync(order);

    public void Delete(Order order) => dbSet.Remove(order);

    public void Update(Order order) => dbSet.Update(order);

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}