using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.Services.Websites;

public interface IConstructorBlockRepository
{
    public Task<IEnumerable<ConstructorBlock>> GetWebsiteComponentsAsync(Guid websiteId);

    public Task<ConstructorBlock?> GetBlockAsync(Guid id);

    public Task<IEnumerable<TextSection>> GetTextSectionByBlockAsync(Guid id);

    public void RemoveSections(IEnumerable<TextSection> sections);
    
    public Task AddSectionsAsync(IEnumerable<TextSection> sections);
    
    public Task AddAsync(ConstructorBlock block);

    public Task AddRangeAsync(IEnumerable<ConstructorBlock> blocks);

    public Task SaveChangesAsync();
}