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
    
    public Task<CreateWebsiteResponse> CreateAsync(string masterId, string name);
    
    public Task SelectTemplateAsync(Guid websiteId, int templateId);

    public Task ChangeWebsiteInfo(string masterId, Guid websiteId, ChangeWebsiteInfoRequest request);
}

public record CreateWebsiteResponse(Guid Id, string Title);

public record ChangeWebsiteInfoRequest(string Title);