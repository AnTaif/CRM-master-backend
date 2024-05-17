namespace MasterCRM.Application.Services.Orders.Stages.Requests;

public record UpdateRangeRequest(IEnumerable<UpdateStageItemRequest>? UpdateStages,
    IEnumerable<Guid>? DeleteStages);