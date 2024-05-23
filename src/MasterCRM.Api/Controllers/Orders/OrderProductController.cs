using System.Security.Claims;
using MasterCRM.Application.Services.Orders.Products;
using MasterCRM.Application.Services.Orders.Products.Requests;
using MasterCRM.Application.Services.Orders.Products.Responses;
using MasterCRM.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Orders;

[ApiController]
[Authorize]
[Route("orders/{orderId}/products")]
public class OrderProductController(IOrderProductService orderProductService) : ControllerBase
{
    [HttpPut("{orderProductId}")]
    [ProducesResponseType(typeof(OrderProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<OrderProductDto>> Update([FromRoute] Guid orderProductId, OrderProductRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var dto = await orderProductService.UpdateAsync(masterId, orderProductId, request);

            if (dto == null)
                return NotFound("OrderProduct not found");

            return Ok(dto);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderProductDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<OrderProductDto>> Add([FromRoute] Guid orderId, OrderProductRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var dto = await orderProductService.CreateAsync(masterId, orderId, request);

            return CreatedAtAction(nameof(Add), dto);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }

    [HttpDelete("{orderProductId}")]
    [ProducesResponseType(typeof(OrderProductDto), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Delete([FromRoute] Guid orderProductId)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            
            var success = await orderProductService.TryDeleteAsync(masterId, orderProductId);

            if (!success)
                return NotFound("OrderProduct not found");
            
            return NoContent();
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }
}