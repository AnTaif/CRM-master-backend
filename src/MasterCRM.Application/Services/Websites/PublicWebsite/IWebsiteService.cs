namespace MasterCRM.Application.Services.Websites.PublicWebsite;

public interface IWebsiteService
{
    /// <summary>
    /// Returns html website page
    /// </summary>
    /// <param name="websiteId">Website id</param>
    /// <param name="masterId">If website not visible then check that current master is owner of the site</param>
    /// <returns></returns>
    public Task GetWebsite(Guid websiteId, string? masterId);
    
    public Task<WebsiteItemResponse?> CreateAsync(string masterId, string title);
    
    public Task<WebsiteItemResponse?> SelectTemplateAsync(string masterId, Guid websiteId, int templateId);

    public Task<WebsiteItemResponse?> ChangeWebsiteInfoAsync(string masterId, Guid websiteId, ChangeWebsiteInfoRequest request);
}

public record WebsiteItemResponse(Guid Id, string Title, int? TemplateId);

public record ChangeWebsiteInfoRequest(string? Title);