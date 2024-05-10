using MasterCRM.Application.Services.Websites.Templates;
using MasterCRM.Domain.Entities.Websites;
using MasterCRM.Domain.Exceptions;

namespace MasterCRM.Application.Services.Websites.PublicWebsite;

public class WebsiteService(IWebsiteRepository websiteRepository, ITemplateRepository templateRepository) 
    : IWebsiteService
{
    public Task GetWebsite(Guid websiteId, string? masterId)
    {
        throw new NotImplementedException();
    }

    public async Task<WebsiteItemResponse?> CreateAsync(string masterId, string title)
    {
        if (await websiteRepository.IsMasterHaveWebsite(masterId))
            return null;
        
        var newWebsite = new Website
        {
            Id = Guid.NewGuid(),
            Title = title,
            OwnerId = masterId
        };

        await websiteRepository.CreateAsync(newWebsite);
        await websiteRepository.SaveChangesAsync();

        return new WebsiteItemResponse(newWebsite.Id, newWebsite.Title, null);
    }

    public async Task<WebsiteItemResponse?> SelectTemplateAsync(string masterId, Guid websiteId, int templateId)
    {
        var website = await websiteRepository.GetByIdAsync(websiteId);

        if (website == null)
            return null;

        if (masterId != website.OwnerId)
            throw new ForbidException("Current user is not the owner of the website");

        var template = await templateRepository.GetByIdAsync(templateId);

        if (template == null)
            throw new NotFoundException("Template not found");
        
        website.TemplateId = template.Id;
        //TODO(!!!): copy elements (+ change ids for different db entries)
        website.Components = template.Components;
        website.GlobalStyles = template.GlobalStyles;
        
        websiteRepository.Update(website);
        await websiteRepository.SaveChangesAsync();

        return new WebsiteItemResponse(website.Id, website.Title, website.TemplateId);
    }

    public async Task<WebsiteItemResponse?> ChangeWebsiteInfoAsync(string masterId, Guid websiteId, ChangeWebsiteInfoRequest request)
    {
        var website = await websiteRepository.GetByIdAsync(websiteId);

        if (website == null)
            return null;

        if (masterId != website.OwnerId)
            throw new ForbidException("Current user is not the owner of the website");

        website.Title = request.Title ?? website.Title;

        websiteRepository.Update(website);
        await websiteRepository.SaveChangesAsync();

        return new WebsiteItemResponse(website.Id, website.Title, website.TemplateId);
    }
}