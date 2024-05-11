using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.Services.Websites.PublicWebsite;

public interface IStyleRepository
{
    public Task<List<Style>> GetWebsiteGlobalStyles(Guid websiteId);
    
    public Task AddAsync(Style style);
    
    public Task AddRangeAsync(IEnumerable<Style> styles);
}