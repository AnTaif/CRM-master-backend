namespace MasterCRM.Application.Services.Websites.PublicWebsite;

public interface IWebsiteService
{
    public Task<WebsiteItemResponse?> GetWebsiteInfo(Guid websiteId, string? masterId);
    
    public Task<WebsiteItemResponse?> CreateAsync(string masterId, CreateWebsiteRequest request);
    
    public Task<WebsiteItemResponse?> SelectTemplateAsync(string masterId, Guid websiteId, int templateId);

    public Task<WebsiteItemResponse?> ChangeWebsiteInfoAsync(string masterId, Guid websiteId, ChangeWebsiteInfoRequest request);
}

public record CreateWebsiteRequest(string Title, string AddressName);

public record WebsiteItemResponse(Guid Id, string Title, string AddressName, int? TemplateId);

public record ChangeWebsiteInfoRequest(string? Title, string? AddressName);