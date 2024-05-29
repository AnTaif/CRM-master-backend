using MasterCRM.Application.Services.Websites.PublicWebsite.Responses;
using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.MapExtensions;

public static class WebsiteExtensions
{
    public static WebsiteDto ToDto(this Website website, string? websitesUrl)
    {
        if (websitesUrl == null)
            return new WebsiteDto(website.Id, website.Title, website.AddressName, null, website.TemplateId);
        
        var url = new Uri(websitesUrl);
        url = new Uri(url, website.AddressName + ".html");

        return new WebsiteDto(website.Id, website.Title, website.AddressName, url.ToString(), website.TemplateId);
    }
}