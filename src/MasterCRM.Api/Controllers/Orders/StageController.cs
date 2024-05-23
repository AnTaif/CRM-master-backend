using System.Security.Claims;
using MasterCRM.Application.Services.Orders.Stages;
using MasterCRM.Application.Services.Orders.Stages.Requests;
using MasterCRM.Application.Services.Orders.Stages.Responses;
using MasterCRM.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Orders;

[ApiController]
[Authorize]
[Route("orders/stages")]
public class StageController(IStageService stageService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StageDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<StageDto>>> GetStages()
    {
        var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var stages = await stageService.GetByMasterAsync(masterId);

        return Ok(stages);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<StageDto>> Update([FromRoute] Guid id, UpdateStageRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            
            var stage = await stageService.UpdateAsync(masterId, id, request);

            if (stage == null)
                return NotFound("Stage not found");

            return Ok(stage);
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }

    [HttpPut]
    public async Task<ActionResult<IEnumerable<StageDto>>> UpdateRange(UpdateRangeRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            
            var stageDtos = await stageService.UpdateRangeAsync(masterId, request);

            if (stageDtos == null)
                return NotFound("Some stage not found");

            return Ok(stageDtos);
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var success = await stageService.TryDeleteAsync(masterId, id);

            if (!success)
                return BadRequest("Stage not found or it is a system");
            
            return NoContent();
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }
}