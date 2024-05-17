using MasterCRM.Application.Services.Orders.Stages;
using MasterCRM.Application.Services.Orders.Stages.Responses;
using MasterCRM.Domain.Entities.Orders;

namespace MasterCRM.Application.MapExtensions;

public static class StageExtensions
{
    public static StageDto ToDto(this Stage stage)
    {
        return new StageDto(stage.Id, stage.Name, stage.Order, stage.IsSystem);
    }
}