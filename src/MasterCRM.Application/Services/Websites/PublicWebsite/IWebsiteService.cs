using MasterCRM.Application.Services.Websites.Constructor.Responses;
using MasterCRM.Application.Services.Websites.PublicWebsite.Requests;
using MasterCRM.Application.Services.Websites.PublicWebsite.Responses;

namespace MasterCRM.Application.Services.Websites.PublicWebsite;

public interface IWebsiteService
{
    public Task<WebsiteDto?> GetWebsiteInfoByMasterAsync(string masterId);

    public Task<WebsiteDto?> GetWebsiteInfoAsync(string address);
    
    public Task<WebsiteDto?> CreateAsync(string masterId, CreateWebsiteRequest request);

    public Task<bool> TryDeleteAsync(string masterId);
    
    public Task<WebsiteDto?> SelectTemplateAsync(string masterId, SelectTemplateRequest request);

    public Task<WebsiteDto?> ChangeWebsiteInfoAsync(string masterId, ChangeWebsiteInfoRequest request);

    public Task<IEnumerable<BlockDto>> GetMainBlocksAsync(string address);
}