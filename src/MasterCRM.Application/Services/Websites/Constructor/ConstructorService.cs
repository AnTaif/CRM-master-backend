using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Websites.Constructor.Requests;
using MasterCRM.Application.Services.Websites.Constructor.Responses;
using MasterCRM.Application.Services.Websites.PublicWebsite;
using MasterCRM.Domain.Exceptions;

namespace MasterCRM.Application.Services.Websites.Constructor;

public class ConstructorService(IWebsiteRepository websiteRepository, IGlobalStylesRepository globalStylesRepository) : IConstructorService
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

    public Task<IEnumerable<BlockDto>> GetMainSectionAsync(string masterid, Guid websiteId)
    {
        throw new NotImplementedException();
    }
}