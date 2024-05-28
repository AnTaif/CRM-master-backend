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
        var stages = await stageRepository.GetAllByMasterAsync(masterId);

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

    public async Task<List<StageDto>?> SaveRangeAsync(string masterId, IEnumerable<StageItemRequest> request)
    {
        var savedStages = request.ToList();

        if (savedStages.Count > 7)
            throw new BadRequestException("There cannot be more than 7 stages");
        
        var stages = await stageRepository.GetAllByMasterAsync(masterId);
        
        // DELETE unused stages
        foreach (var stage in stages)
            if (savedStages.All(stageReq => stageReq.Id != stage.Id))
                stageRepository.Delete(stage);

        foreach (var stageReq in savedStages)
        {
            if (stageReq.Id == null)
            {
                var newStage = new Stage
                {
                    Id = Guid.NewGuid(),
                    MasterId = masterId,
                    Name = stageReq.Name,
                    StageType = StageType.Default,
                    Order = stageReq.Order
                };

                await stageRepository.AddAsync(newStage);
                continue;
            }

            var stage = await stageRepository.GetByIdAsync((Guid)stageReq.Id);

            if (stage == null)
                throw new NotFoundException($"Stage with id: {stageReq.Id} not found");
            
            if (stage.MasterId != masterId)
                throw new ForbidException("Current user is not the owner of the stage");
            
            stage.Update(stageReq.Name, stageReq.Order);
        }

        await stageRepository.SaveChangesAsync();

        stages = await stageRepository.GetAllByMasterAsync(masterId);

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