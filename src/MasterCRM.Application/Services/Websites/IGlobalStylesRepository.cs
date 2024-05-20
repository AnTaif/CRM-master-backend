using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.Services.Websites;

public interface IGlobalStylesRepository
{
    public Task<GlobalStyles?> GetWebsiteGlobalStyles(Guid websiteId);
    
    public Task AddAsync(GlobalStyles styles);

    public void Update(GlobalStyles styles);

    public void Remove(GlobalStyles styles);

    public Task SaveChangesAsync();
}