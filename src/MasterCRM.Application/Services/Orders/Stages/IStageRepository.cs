using System.Linq.Expressions;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;

namespace MasterCRM.Application.Services.Orders.Stages;

public interface IStageRepository
{
    public Task<Stage> GetStartByMasterAsync(string masterId);

    public Task<Stage?> GetByIdAsync(Guid id);

    public Task<Stage?> GetWithTabByMaster(string masterId, short stageTab);

    public Task<IEnumerable<Stage>> GetAllByMasterAsync(string masterId);
    
    public Task<IEnumerable<Stage>> GetAllByPredicateAsync(Expression<Func<Stage, bool>> predicate);
    
    public void Update(Stage stage);
    
    public void UpdateRange(IEnumerable<Stage> stages);

    public void Delete(Stage stage);
    
    public Task AddAsync(Stage stage);
    
    public Task AddRangeAsync(IEnumerable<Stage> stages);

    public Task SaveChangesAsync();
}