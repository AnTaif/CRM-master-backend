using System.Linq.Expressions;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;

namespace MasterCRM.Application.Services.Orders.History;

public interface IOrderHistoryRepository
{
    public Task<IEnumerable<OrderHistory>> GetAllByPredicateAsync(Expression<Func<OrderHistory, bool>> predicate);

    public Task<OrderHistory?> GetByIdAsync(Guid id);

    public Task CreateAsync(OrderHistory history);

    public void Update(OrderHistory history);

    public void Delete(OrderHistory history);

    public Task SaveChangesAsync();
}