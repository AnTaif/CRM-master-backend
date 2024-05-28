using MasterCRM.Application.Services.Orders.Stages.Requests;
using MasterCRM.Application.Services.Orders.Stages.Responses;

namespace MasterCRM.Application.Services.Orders.Stages;

public interface IStageService
{
    public Task<List<StageDto>> GetByMasterAsync(string masterId);

    public Task<StageDto?> UpdateAsync(string masterId, Guid id, UpdateStageRequest request);

    public Task<List<StageDto>?> SaveRangeAsync(string masterId, IEnumerable<StageItemRequest> request);
        
    public Task<bool> TryDeleteAsync(string masterId, Guid id);
}