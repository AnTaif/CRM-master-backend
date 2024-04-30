using System.Linq.Expressions;
using MasterCRM.Application.Services.Orders.Stages;
using MasterCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Repositories;

public class StageRepository(CrmDbContext context) : IStageRepository
{
    private DbSet<Stage> dbSet => context.Stages;
    
    public async Task<Stage> GetStartByMasterAsync(string masterId) => 
        await dbSet.FirstAsync(stage => stage.MasterId == masterId && stage.StageType == StageType.Start);
    
    public async Task<Stage?> GetByIdAsync(Guid id) => await dbSet.FindAsync(id);
    
    public async Task<IEnumerable<Stage>> GetAllByPredicateAsync(Expression<Func<Stage, bool>> predicate) => 
        await dbSet.Where(predicate).ToListAsync();
}