using MasterCRM.Application.Services.Websites.PublicWebsite.Requests;
using MasterCRM.Application.Services.Websites.PublicWebsite.Responses;
using MasterCRM.Application.Services.Websites.Templates;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Websites;
using MasterCRM.Domain.Exceptions;
using MasterCRM.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Application.Services.Websites.PublicWebsite;

public class WebsiteService(
        IWebsiteRepository websiteRepository, 
        ITemplateRepository templateRepository, 
        IFileStorage fileStorage,
        IConstructorBlockRepository constructorBlockRepository,
        IGlobalStylesRepository globalStylesRepository,
        UserManager<Master> userManager) : IWebsiteService
{
    public async Task<WebsiteDto?> GetWebsiteInfo(string masterId)
    {
        var master = await userManager.FindByIdAsync(masterId);

        if (master == null)
            throw new NotFoundException("Master not found");
        
        if (master.WebsiteId == null)
            throw new NotFoundException("Website not found");
        
        var website = await websiteRepository.GetByIdAsync((Guid)master.WebsiteId);

        if (website == null)
            return null;

        if (masterId != website.OwnerId)
            throw new ForbidException("Current user is not the owner of the website");

        return new WebsiteDto(website.Id, website.Title, website.AddressName, website.TemplateId);
    }

    public async Task<WebsiteDto?> CreateAsync(string masterId, CreateWebsiteRequest request)
    {
        var master = await userManager.FindByIdAsync(masterId);

        if (master == null)
            throw new NotFoundException("Master not found");
        
        if (master.WebsiteId != null)
            return null;

        if (!await websiteRepository.IsAddressUnique(request.AddressName))
            throw new BadRequestException("Website address name is already in use: " + request.AddressName);
            
        var newWebsite = new Website
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            AddressName = request.AddressName,
            OwnerId = masterId
        };
            
        await websiteRepository.CreateAsync(newWebsite);
        master.WebsiteId = newWebsite.Id;
        await websiteRepository.SaveChangesAsync();

        return new WebsiteDto(newWebsite.Id, newWebsite.Title, newWebsite.AddressName, null);
    }

    public async Task<bool> TryDeleteAsync(string masterId)
    {
        var master = await userManager.FindByIdAsync(masterId);

        if (master == null)
            throw new NotFoundException("Master not found");
        
        if (master.WebsiteId == null)
            throw new NotFoundException("Website not found");
        
        var website = await websiteRepository.GetByIdAsync((Guid)master.WebsiteId);

        if (website == null)
            return false;
        
        websiteRepository.Delete(website);
        master.WebsiteId = null;
        await websiteRepository.SaveChangesAsync();

        return true;
    }

    public async Task<WebsiteDto?> SelectTemplateAsync(string masterId, SelectTemplateRequest request)
    {
        var master = await userManager.FindByIdAsync(masterId);

        if (master == null)
            throw new NotFoundException("Master not found");
        
        if (master.WebsiteId == null)
            throw new NotFoundException("Website not found");
        
        var templateId = request.TemplateId;
        var websiteId = (Guid)master.WebsiteId;
        var website = await websiteRepository.GetByIdAsync(websiteId);

        if (website == null)
            return null;

        var template = await templateRepository.GetByIdAsync(templateId);

        if (template == null)
            throw new NotFoundException("Template not found");
        
        website.TemplateId = template.Id;
        
        var templateStyles = template.GlobalStyles;
        
        if (website.GlobalStyles != null)
            globalStylesRepository.Remove(website.GlobalStyles);
        await globalStylesRepository.AddAsync(new GlobalStyles
        {
            TemplateId = null,
            WebsiteId = websiteId,
            FontFamily = templateStyles.FontFamily,
            BackgroundColor = templateStyles.BackgroundColor,
            H1Color = templateStyles.H1Color,
            PColor = templateStyles.PColor,
            ButtonColor = templateStyles.ButtonColor
        });
        
        var websiteComponents = new List<ConstructorBlock>();
        foreach (var component in template.Components)
        {
            switch (component)
            {
                case HeaderBlock headerBlock:
                    websiteComponents.Add(new HeaderBlock
                    {
                        Title = headerBlock.Title,
                        Order = headerBlock.Order,
                        TemplateId = null,
                        WebsiteId = website.Id,
                        Type = headerBlock.Type
                    });
                    break;
                case H1Block h1Block:
                    websiteComponents.Add(new H1Block
                    {
                        Title = h1Block.Title,
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
                        Title = textBlock.Title,
                        Order = textBlock.Order,
                        TemplateId = null,
                        WebsiteId = website.Id,
                        Text = textBlock.Text
                    });
                    break;
                case CatalogBlock catalogBlock:
                    websiteComponents.Add(new CatalogBlock
                    {
                        Title = catalogBlock.Title,
                        Order = catalogBlock.Order,
                        TemplateId = null,
                        WebsiteId = website.Id,
                        Type = catalogBlock.Type
                    });
                    break;
                case MultipleTextBlock multipleTextBlock:
                    websiteComponents.Add(new MultipleTextBlock
                    {
                        Title = multipleTextBlock.Title,
                        Order = multipleTextBlock.Order,
                        TemplateId = null,
                        WebsiteId = website.Id,
                        TextSections = multipleTextBlock.TextSections
                            .Select(section => new TextSection(section.Title, section.Text, section.Id))
                            .ToList()
                    });
                    break;
                case FooterBlock footerBlock:
                    websiteComponents.Add(new FooterBlock
                    {
                        Title = footerBlock.Title,
                        Order = footerBlock.Order,
                        TemplateId = null,
                        WebsiteId = website.Id,
                        Type = footerBlock.Type
                    });
                    break;
            }
        }
        if (website.Components != null)
            constructorBlockRepository.RemoveRangeAsync(website.Components);
        await constructorBlockRepository.AddRangeAsync(websiteComponents);

        await websiteRepository.SaveChangesAsync();

        return new WebsiteDto(website.Id, website.Title, website.AddressName, website.TemplateId);
    }

    public async Task<WebsiteDto?> ChangeWebsiteInfoAsync(string masterId, ChangeWebsiteInfoRequest request)
    {
        var master = await userManager.FindByIdAsync(masterId);

        if (master == null)
            throw new NotFoundException("Master not found");
        
        if (master.WebsiteId == null)
            throw new NotFoundException("Website not found");

        var websiteId = (Guid)master.WebsiteId;
        var website = await websiteRepository.GetByIdAsync(websiteId);

        if (website == null)
            return null;

        if (masterId != website.OwnerId)
            throw new ForbidException("Current user is not the owner of the website");

        website.Title = request.Title ?? website.Title;

        if (request.AddressName != null && !website.AddressName.Equals(request.AddressName))
        {
            if (!await websiteRepository.IsAddressUnique(request.AddressName))
                throw new BadRequestException("Website address name is already in use: " + request.AddressName);
            website.AddressName = request.AddressName;
        }

        websiteRepository.Update(website);
        await websiteRepository.SaveChangesAsync();

        return new WebsiteDto(website.Id, website.Title, website.AddressName, website.TemplateId);
    }
}