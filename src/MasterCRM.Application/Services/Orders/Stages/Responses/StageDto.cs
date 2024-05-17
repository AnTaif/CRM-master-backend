namespace MasterCRM.Application.Services.Orders.Stages.Responses;

public record StageDto(Guid Id, string Name, short Order, bool IsSystem);