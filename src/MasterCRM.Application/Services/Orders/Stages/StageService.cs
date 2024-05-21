using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Orders.Stages.Requests;
using MasterCRM.Application.Services.Orders.Stages.Responses;
using MasterCRM.Domain.Entities.Orders;
using MasterCRM.Domain.Exceptions;

namespace MasterCRM.Application.Services.Orders.Stages;

public class StageService(IStageRepository stageRepository) : IStageService
{
    public async Task<List<StageDto>> GetByMasterAsync(string masterId)
    {
        var stages = await stageRepository.GetAllByPredicateAsync(stage => stage.MasterId == masterId);

        return stages.Select(stage => stage.ToDto()).ToList();
    }

    public async Task<StageDto?> UpdateAsync(string masterId, Guid id, UpdateStageRequest request)
    {
        var stage = await stageRepository.GetByIdAsync(id);

        if (stage == null)
            return null;

        if (stage.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the stage");

        stage.Update(request.Name, request.Order);
        await stageRepository.SaveChangesAsync();

        return stage.ToDto();
    }

    public async Task<List<StageDto>?> UpdateRangeAsync(string masterId, UpdateRangeRequest request)
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
                
                if (stage.MasterId != masterId)
                    throw new ForbidException("Current user is not the owner of the stage");

                stage.Update(updateRequest.Name, updateRequest.Order);
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
                    return null;
                
                if (deletedStage.MasterId != masterId)
                    throw new ForbidException("Current user is not the owner of the stage");
                
                stageRepository.Delete(deletedStage);
            }
        }
        
        await stageRepository.SaveChangesAsync();
        return stages.Select(stage => stage.ToDto()).ToList();
    }

    public async Task<bool> TryDeleteAsync(string masterId, Guid id)
    {
        var stage = await stageRepository.GetByIdAsync(id);

        if (stage == null)
            return false;
        
        if (stage.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the stage");

        if (stage.IsSystem)
            return false;
        
        stageRepository.Delete(stage);
        await stageRepository.SaveChangesAsync();

        return true;
    }
}