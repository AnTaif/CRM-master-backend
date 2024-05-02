using System.Linq.Expressions;
using MasterCRM.Application.Services.Orders;
using MasterCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories;

public class OrderRepository(CrmDbContext context) : IOrderRepository
{
    private DbSet<Order> dbSet => context.Orders;

    public async Task<IEnumerable<Order>> GetAllByPredicateAsync(Expression<Func<Order, bool>> predicate) => 
        await dbSet
            .Include(order => order.Stage)
            .Include(order => order.Client)
            .Where(predicate)
            .ToListAsync();

    public async Task<Order?> GetByIdAsync(Guid id) =>
        await dbSet
            .Include(order => order.Stage)
            .Include(order => order.Client)
            .Include(order => order.OrderProducts)
            .ThenInclude(orderProduct => orderProduct.Product)
            .ThenInclude(product => product.Photos)
            .FirstOrDefaultAsync(e => e.Id == id);

    public async Task CreateAsync(Order order) => await dbSet.AddAsync(order);

    public void Delete(Order order) => dbSet.Remove(order);

    public void Update(Order order) => dbSet.Update(order);

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}