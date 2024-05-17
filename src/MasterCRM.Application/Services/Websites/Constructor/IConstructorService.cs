using MasterCRM.Application.Services.Websites.Constructor.Requests;
using MasterCRM.Application.Services.Websites.Constructor.Responses;

namespace MasterCRM.Application.Services.Websites.Constructor;

public interface IConstructorService
{
    public Task<GlobalStylesDto?> GetGlobalStylesAsync(string masterId, Guid websiteId);

    public Task<GlobalStylesDto?> ChangeGlobalStylesAsync(string masterId, Guid websiteId, ChangeGlobalStylesRequest request);
    
    public Task<IEnumerable<BlockDto>> GetMainSectionAsync(string masterid, Guid websiteId);

    // public Task GetOrderRegistrationSection(string masterId, Guid websiteId);
    //
    // public Task GetProductCardSection(string masterId, Guid websiteId);
}