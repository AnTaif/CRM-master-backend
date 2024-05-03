namespace MasterCRM.Application.Services.Orders.Stages;

public interface IStageService
{
    public Task<List<StageDto>> GetByMasterAsync(string masterId);

    public Task<StageDto?> UpdateAsync(Guid id, UpdateStageRequest request);

    public Task<List<StageDto>?> UpdateRangeAsync(UpdateRangeRequest request);
        
    public Task<bool> TryDeleteAsync(Guid id);
}

public record StageDto(Guid Id, string Name, short Order, bool IsSystem);

public record UpdateStageRequest(string? Name, short? Order);

public record UpdateRangeRequest(IEnumerable<UpdateStageItemRequest>? UpdateStages,
    IEnumerable<Guid>? DeleteStages);

public record UpdateStageItemRequest(Guid Id, string? Name, short? Order);