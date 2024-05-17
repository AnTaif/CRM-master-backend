using MasterCRM.Application.Services.Websites.PublicWebsite.Requests;
using MasterCRM.Application.Services.Websites.PublicWebsite.Responses;

namespace MasterCRM.Application.Services.Websites.PublicWebsite;

public interface IWebsiteService
{
    public Task<WebsiteDto?> GetWebsiteInfo(Guid websiteId, string? masterId);
    
    public Task<WebsiteDto?> CreateAsync(string masterId, CreateWebsiteRequest request);
    
    public Task<WebsiteDto?> SelectTemplateAsync(string masterId, Guid websiteId, SelectTemplateRequest request);

    public Task<WebsiteDto?> ChangeWebsiteInfoAsync(string masterId, Guid websiteId, ChangeWebsiteInfoRequest request);
}