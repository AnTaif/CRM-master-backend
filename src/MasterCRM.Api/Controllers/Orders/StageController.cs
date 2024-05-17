using System.Security.Claims;
using MasterCRM.Application.Services.Orders.Stages;
using MasterCRM.Application.Services.Orders.Stages.Requests;
using MasterCRM.Application.Services.Orders.Stages.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Orders;

[ApiController]
[Authorize]
[Route("orders/stages")]
public class StageController(IStageService stageService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StageDto>>> GetStages()
    {
        var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var stages = await stageService.GetByMasterAsync(masterId);

        return Ok(stages);
    }

    // [HttpPost("reorder")]
    // public async Task<ActionResult<IEnumerable<StageDto>>> ReorderStages(IEnumerable<Guid> ids)
    // {
    //     var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    //
    //     var stages = await stageService.ReorderItemsAsync(masterId, ids);
    //     
    //     return Ok(stages);
    // }

    [HttpPut("{id}")]
    public async Task<ActionResult<StageDto>> Update([FromRoute] Guid id, UpdateStageRequest request)
    {
        //TODO: check masterId of stage
        //var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        var stage = await stageService.UpdateAsync(id, request);

        if (stage == null)
            return NotFound();

        return Ok(stage);
    }

    [HttpPut]
    public async Task<ActionResult<IEnumerable<StageDto>>> UpdateRange(UpdateRangeRequest request)
    {
        var stageDtos = await stageService.UpdateRangeAsync(request);

        if (stageDtos == null)
            return NotFound();

        return Ok(stageDtos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        //TODO: check masterId of stage
        //var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var success = await stageService.TryDeleteAsync(id);

        if (!success)
            return BadRequest();
        
        return NoContent();
    }
}