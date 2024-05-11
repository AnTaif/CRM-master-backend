using MasterCRM.Application.Services.Websites.PublicWebsite;
using MasterCRM.Domain.Exceptions;

namespace MasterCRM.Application.Services.Websites.Constructor;

public class ConstructorService(IWebsiteRepository websiteRepository, IStyleRepository styleRepository) : IConstructorService
{
    public async Task<IEnumerable<StyleDto>?> GetGlobalStylesAsync(string masterId, Guid websiteId)
    {
        var website = await websiteRepository.GetByIdAsync(websiteId);

        if (website == null)
            return null;

        if (website.OwnerId != masterId)
            throw new ForbidException("Current user is not the owner of the website");

        var globalStyles = await styleRepository.GetWebsiteGlobalStyles(websiteId);

        return globalStyles.Select(style => new StyleDto
        {
            Selector = style.Selector,
            Properties = new Dictionary<string, string>(style.Properties)
        });
    }

    public Task<IEnumerable<BlockDto>> GetMainSectionAsync(string masterid, Guid websiteId)
    {
        throw new NotImplementedException();
    }
}