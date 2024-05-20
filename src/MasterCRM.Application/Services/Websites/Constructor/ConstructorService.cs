using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Websites.Constructor.Requests;
using MasterCRM.Application.Services.Websites.Constructor.Responses;
using MasterCRM.Domain.Entities.Websites;
using MasterCRM.Domain.Exceptions;

namespace MasterCRM.Application.Services.Websites.Constructor;

public class ConstructorService(IWebsiteRepository websiteRepository, IGlobalStylesRepository globalStylesRepository,
    IConstructorBlockRepository blockRepository) : IConstructorService
{
    public async Task<GlobalStylesDto?> GetGlobalStylesAsync(string masterId, Guid websiteId)
    {
        var website = await websiteRepository.GetByIdAsync(websiteId);

        if (website == null)
            throw new NotFoundException("Website not found");

        if (website.OwnerId != masterId)
            throw new ForbidException("Current user is not the owner of the website");

        var globalStyles = await globalStylesRepository.GetWebsiteGlobalStyles(websiteId);
        
        return globalStyles?.ToDto();
    }

    public async Task<GlobalStylesDto?> ChangeGlobalStylesAsync(string masterId, Guid websiteId, ChangeGlobalStylesRequest request)
    {
        var website = await websiteRepository.GetByIdAsync(websiteId);

        if (website == null)
            throw new NotFoundException("Website not found");

        if (website.OwnerId != masterId)
            throw new ForbidException("Current user is not the owner of the website");
        
        var globalStyles = await globalStylesRepository.GetWebsiteGlobalStyles(websiteId);

        if (globalStyles == null)
            return null;
        
        globalStyles.FontFamily = request.FontFamily ?? globalStyles.FontFamily;
        globalStyles.BackgroundColor = request.BackgroundColor ?? globalStyles.BackgroundColor;
        globalStyles.H1Color = request.H1Color ?? globalStyles.H1Color;
        globalStyles.PColor = request.PColor ?? globalStyles.PColor;
        globalStyles.ButtonColor = request.ButtonColor ?? globalStyles.ButtonColor;

        await globalStylesRepository.SaveChangesAsync();

        return globalStyles.ToDto();
    }

    public async Task<IEnumerable<BlockDto>> GetMainSectionAsync(string masterId, Guid websiteId)
    {
        var website = await websiteRepository.GetByIdAsync(websiteId);

        if (website == null)
            throw new NotFoundException("Website not found");

        if (website.OwnerId != masterId)
            throw new ForbidException("Current user is not the owner of the website");

        var mainBlocks = await blockRepository.GetWebsiteComponentsAsync(websiteId);

        return mainBlocks.Select(block => block.ToDto());
    }

    public async Task<BlockDto?> ChangeBlockAsync(string masterId, Guid websiteId, Guid id, ChangeBlockRequest request)
    {
        var website = await websiteRepository.GetByIdAsync(websiteId);

        if (website == null)
            throw new NotFoundException("Website not found");

        if (website.OwnerId != masterId)
            throw new ForbidException("Current user is not the owner of the website");

        var block = await blockRepository.GetBlockAsync(id);

        if (block == null)
            return null;
        
        switch (block)
        {
            case HeaderBlock headerBlock:
                if (request.Type.HasValue)
                    headerBlock.Type = request.Type.Value;
                break;
            case TextBlock textBlock:
                if (!string.IsNullOrEmpty(request.Text))
                    textBlock.Text = request.Text;
                break;
            case H1Block h1Block:
                if (!string.IsNullOrEmpty(request.H1Text))
                    h1Block.H1Text = request.H1Text;
                if (!string.IsNullOrEmpty(request.PText))
                    h1Block.PText = request.PText;
                if (!string.IsNullOrEmpty(request.ImageUrl))
                    h1Block.ImageUrl = request.ImageUrl;
                break;
            case CatalogBlock catalogBlock:
                if (request.Type.HasValue)
                    catalogBlock.Type = request.Type.Value;
                break;
            case MultipleTextBlock multipleTextBlock:
                if (request.TextSections != null)
                    multipleTextBlock.TextSections = new Dictionary<string, string>(request.TextSections);
                break;
            case FooterBlock footerBlock:
                if (request.Type.HasValue)
                    footerBlock.Type = request.Type.Value;
                break;
            default:
                throw new InvalidOperationException("Unknown block type");
        }

        await blockRepository.SaveChangesAsync();

        return block.ToDto();
    }
}