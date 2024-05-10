using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.Services.Websites.PublicWebsite;

public interface IWebsiteRepository
{
    public Task<bool> IsMasterHaveWebsite(string masterId);
    
    public Task<Website?> GetByIdAsync(Guid id);
    
    public Task CreateAsync(Website website);
    
    public void Update(Website website);
    
    public Task SaveChangesAsync();
}