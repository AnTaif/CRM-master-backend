using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.Services.Websites;

public interface IWebsiteRepository
{
    public Task<bool> IsMasterHaveWebsite(string masterId);

    public Task<string?> GetOwnerIdAsync(string address);
    
    public Task<Website?> GetByIdAsync(Guid id);
    
    public Task CreateAsync(Website website);

    public Task<bool> IsAddressUnique(string address);
    
    public void Update(Website website);

    public void Delete(Website website);
    
    public Task SaveChangesAsync();
}