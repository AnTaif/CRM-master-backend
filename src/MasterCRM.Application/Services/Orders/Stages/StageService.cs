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

    public async Task<List<StageDto>?> UpdateRangeAsync(UpdateRangeRequest request)
    {
        var stages = new List<Stage>();

        var updateRequests = request.UpdateStages;
        if (updateRequests != null)
        {
            foreach (var updateRequest in updateRequests)
            {
                var stage = await stageRepository.GetByIdAsync(updateRequest.Id);

                if (stage == null)
                    return null;

                stage.Name = updateRequest.Name ?? stage.Name;
                stage.Order = updateRequest.Order ?? stage.Order;
                
                stageRepository.Update(stage);
                stages.Add(stage);
            }
        }
        
        var deletedStages = request.DeleteStages;
        if (deletedStages != null)
        {
            foreach (var deletedStageId in deletedStages)
            {
                var deletedStage = await stageRepository.GetByIdAsync(deletedStageId);

                if (deletedStage == null)
                    throw new Exception($"Stage with this id: \"{deletedStageId}\" not found");
                
                stageRepository.Delete(deletedStage);
            }
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