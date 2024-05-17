namespace MasterCRM.Application.Services.Orders.Stages.Requests;

public record UpdateStageItemRequest(Guid Id, string? Name, short? Order);