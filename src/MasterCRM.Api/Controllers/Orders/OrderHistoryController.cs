using System.Security.Claims;
using MasterCRM.Application.Services.Orders.History;
using MasterCRM.Application.Services.Orders.History.Responses;
using MasterCRM.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Orders;

[ApiController]
[Authorize]
[Route("orders/{orderId}/history")]
public class OrderHistoryController(IOrderHistoryService historyService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrderHistoryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetByOrder([FromRoute] Guid orderId)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            
            var history = await historyService.GetOrderHistoryAsync(masterId, orderId);

            if (history == null)
                return NotFound("Order not found");
            
            return Ok(history);
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }
}