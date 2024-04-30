using System.Linq.Expressions;
using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.Services.Orders.Stages;

public interface IStageRepository
{
    public Task<Stage> GetStartByMasterAsync(string masterId);

    public Task<Stage?> GetByIdAsync(Guid id);
    
    public Task<IEnumerable<Stage>> GetAllByPredicateAsync(Expression<Func<Stage, bool>> predicate);
}