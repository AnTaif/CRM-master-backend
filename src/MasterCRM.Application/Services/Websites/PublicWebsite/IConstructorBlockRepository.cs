using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.Services.Websites.PublicWebsite;

public interface IConstructorBlockRepository
{
    public Task AddAsync(ConstructorBlock block);

    public Task AddRangeAsync(IEnumerable<ConstructorBlock> blocks);
}