namespace MasterCRM.Application.Services.Orders.Stages;

public interface IStageService
{
    public Task<List<StageDto>> GetByMasterAsync(string masterId);
    
    public Task<List<StageDto>> ReorderItemsAsync(string masterId, IEnumerable<Guid> ids);

    public Task<StageDto?> UpdateAsync(Guid id, UpdateStageRequest request);
        
    public Task<bool> TryDeleteAsync(Guid id);
}

public record StageDto(Guid Id, string Name, int Order, bool IsSystem);

public record UpdateStageRequest(string? Name);