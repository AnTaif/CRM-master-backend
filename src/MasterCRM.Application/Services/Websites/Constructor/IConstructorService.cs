using MasterCRM.Application.Services.Websites.Constructor.Requests;
using MasterCRM.Application.Services.Websites.Constructor.Responses;

namespace MasterCRM.Application.Services.Websites.Constructor;

public interface IConstructorService
{
    public Task<GlobalStylesDto?> GetGlobalStylesAsync(string masterId);

    public Task<GlobalStylesDto?> ChangeGlobalStylesAsync(string masterId, ChangeGlobalStylesRequest request);
    
    public Task<IEnumerable<BlockDto>> GetMainSectionAsync(string masterId);

    public Task<BlockDto?> ChangeBlockAsync(string masterId, Guid id, ChangeBlockRequest request);

    public Task<string> SaveWebsiteAsync(string masterId, Stream stream);

    // public Task GetOrderRegistrationSection(string masterId, Guid websiteId);
    //
    // public Task GetProductCardSection(string masterId, Guid websiteId);
}