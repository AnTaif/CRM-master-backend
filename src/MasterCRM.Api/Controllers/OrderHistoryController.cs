using MasterCRM.Application.Services.Orders.History;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers;

[ApiController]
[Authorize]
[Route("orders/{orderId}/history")]
public class OrderHistoryController(IOrderHistoryService historyService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetByOrder([FromRoute] Guid orderId)
    {
        var history = await historyService.GetOrderHistoryAsync(orderId);

        return Ok(history);
    }
}