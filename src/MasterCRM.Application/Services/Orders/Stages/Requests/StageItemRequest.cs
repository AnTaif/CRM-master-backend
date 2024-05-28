namespace MasterCRM.Application.Services.Orders.Stages.Requests;

public record StageItemRequest(Guid? Id, string Name, short Order);