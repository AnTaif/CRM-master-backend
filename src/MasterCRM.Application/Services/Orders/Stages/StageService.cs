using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.Services.Orders.Stages;

public class StageService(IStageRepository stageRepository) : IStageService
{
    public async Task<List<StageDto>> GetByMasterAsync(string masterId)
    {
        var stages = await stageRepository.GetAllByPredicateAsync(stage => stage.MasterId == masterId);
        var stagesList = stages.ToList();
        
        stagesList.Sort((stage1, stage2) => stage1.Order.CompareTo(stage2.Order));

        return stagesList.Select(stage => new StageDto(stage.Id, stage.Name, stage.Order, stage.IsSystem)).ToList();
    }

    public async Task<List<StageDto>> ReorderItemsAsync(string masterId, IEnumerable<Guid> ids)
    {
        var stages = await stageRepository.GetAllByPredicateAsync(stage => stage.MasterId == masterId);
        var stagesList = stages.ToList();

        var idsList = ids.ToList();
        for (var i = 0; i < idsList.Count; i++)
        {
            var id = idsList[i];
            var stage = stagesList.First(stage => stage.Id == id);

            stage.Order = (short)i;
        }
        
        stageRepository.UpdateRange(stagesList);
        await stageRepository.SaveChangesAsync();
        
        return stagesList.Select(stage => new StageDto(stage.Id, stage.Name, stage.Order, stage.IsSystem)).ToList();
    }

    public async Task<StageDto?> UpdateAsync(Guid id, UpdateStageRequest request)
    {
        var stage = await stageRepository.GetByIdAsync(id);

        if (stage == null)
            return null;

        stage.Name = request.Name ?? stage.Name;
        
        stageRepository.Update(stage);
        await stageRepository.SaveChangesAsync();

        return new StageDto(stage.Id, stage.Name, stage.Order, stage.IsSystem);
    }

    public async Task<List<StageDto>?> UpdateRangeAsync(IEnumerable<UpdateStageItemRequest> requests)
    {
        var stages = new List<Stage>();
        
        foreach (var request in requests)
        {
            var stage = await stageRepository.GetByIdAsync(request.Id);

            if (stage == null)
                return null;

            stage.Name = request.Name ?? stage.Name;
            stage.Order = request.Order ?? stage.Order;
            
            stageRepository.Update(stage);
            stages.Add(stage);
        }
        await stageRepository.SaveChangesAsync();

        return stages.Select(stage => new StageDto(stage.Id, stage.Name, stage.Order, stage.IsSystem)).ToList();
    }

    public async Task<bool> TryDeleteAsync(Guid id)
    {
        var stage = await stageRepository.GetByIdAsync(id);

        if (stage == null)
            return false;

        if (stage.IsSystem)
            return false;
        
        stageRepository.Delete(stage);
        await stageRepository.SaveChangesAsync();

        return true;
    }
}