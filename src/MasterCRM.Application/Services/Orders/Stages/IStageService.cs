using MasterCRM.Application.Services.Orders.Stages.Requests;
using MasterCRM.Application.Services.Orders.Stages.Responses;

namespace MasterCRM.Application.Services.Orders.Stages;

public interface IStageService
{
    public Task<List<StageDto>> GetByMasterAsync(string masterId);

    public Task<StageDto?> UpdateAsync(Guid id, UpdateStageRequest request);

    public Task<List<StageDto>?> UpdateRangeAsync(UpdateRangeRequest request);
        
    public Task<bool> TryDeleteAsync(Guid id);
}