namespace MasterCRM.Application.Services.Orders.Stages.Requests;

public record UpdateRangeRequest(
    IEnumerable<AddStageRequest>? AddStages,
    IEnumerable<UpdateStageItemRequest>? UpdateStages,
    IEnumerable<Guid>? DeleteStages);