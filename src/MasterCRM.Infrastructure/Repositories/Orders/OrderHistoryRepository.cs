using System.Linq.Expressions;
using MasterCRM.Application.Services.Orders.History;
using MasterCRM.Domain.Entities.Orders;
using MasterCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories.Orders;

public class OrderHistoryRepository(CrmDbContext context) : IOrderHistoryRepository
{
    private DbSet<OrderHistory> dbSet => context.OrderHistories;

    public async Task<IEnumerable<OrderHistory>>
        GetAllByPredicateAsync(Expression<Func<OrderHistory, bool>> predicate) =>
        await dbSet.Where(predicate).OrderByDescending(history => history.Date).ToListAsync();

    public async Task<OrderHistory?> GetByIdAsync(Guid id) => await dbSet.FindAsync(id);

    public async Task CreateAsync(OrderHistory history) => await dbSet.AddAsync(history);

    public void Delete(OrderHistory history) => dbSet.Remove(history);

    public void Update(OrderHistory history) => dbSet.Update(history);

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}