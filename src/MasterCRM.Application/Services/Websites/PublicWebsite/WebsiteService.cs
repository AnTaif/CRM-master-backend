using MasterCRM.Application.Services.Websites.Templates;
using MasterCRM.Domain.Entities.Websites;
using MasterCRM.Domain.Exceptions;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Application.Services.Websites.PublicWebsite;

public class WebsiteService(
        IWebsiteRepository websiteRepository, 
        ITemplateRepository templateRepository, 
        IFileStorage fileStorage,
        IConstructorBlockRepository constructorBlockRepository,
        IStyleRepository styleRepository) : IWebsiteService
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
        
        var websiteGlobalStyles = new List<Style>();
        foreach (var style in template.GlobalStyles)
        {
            websiteGlobalStyles.Add(new Style
            {
                Element = style.Element,
                Properties = new Dictionary<string, string>(style.Properties),
                TemplateId = null,
                WebsiteId = website.Id
            });
        }
        
        await styleRepository.AddRangeAsync(websiteGlobalStyles);
        
        var websiteComponents = new List<ConstructorBlock>();
        foreach (var component in template.Components)
        {
            switch (component)
            {
                case HeaderBlock headerBlock:
                    websiteComponents.Add(new HeaderBlock
                    {
                        Order = headerBlock.Order,
                        TemplateId = null,
                        WebsiteId = website.Id,
                        Type = headerBlock.Type
                    });
                    break;
                case H1Block h1Block:
                    websiteComponents.Add(new H1Block
                    {
                        Order = h1Block.Order,
                        TemplateId = null,
                        WebsiteId = website.Id,
                        H1Text = h1Block.H1Text,
                        PText = h1Block.PText,
                        ImageUrl = fileStorage.CopyToPublic(h1Block.ImageUrl)
                    });
                    break;
                case TextBlock textBlock:
                    websiteComponents.Add(new TextBlock
                    {
                        Order = textBlock.Order,
                        TemplateId = null,
                        WebsiteId = website.Id,
                        Text = textBlock.Text
                    });
                    break;
                case CatalogBlock catalogBlock:
                    websiteComponents.Add(new CatalogBlock
                    {
                        Order = catalogBlock.Order,
                        TemplateId = null,
                        WebsiteId = website.Id,
                        Type = catalogBlock.Type
                    });
                    break;
                case FooterBlock footerBlock:
                    websiteComponents.Add(new FooterBlock
                    {
                        Order = footerBlock.Order,
                        TemplateId = null,
                        WebsiteId = website.Id,
                        Type = footerBlock.Type
                    });
                    break;
            }
        }
        
        await constructorBlockRepository.AddRangeAsync(websiteComponents);

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