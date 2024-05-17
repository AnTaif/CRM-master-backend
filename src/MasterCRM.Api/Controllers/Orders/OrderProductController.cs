using MasterCRM.Application.Services.Orders.Products;
using MasterCRM.Application.Services.Orders.Products.Requests;
using MasterCRM.Application.Services.Orders.Products.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Orders;

[ApiController]
[Route("orders/{orderId}/products")]
public class OrderProductController(IOrderProductService orderProductService) : ControllerBase
{
    [HttpPut("{orderProductId}")]
    public async Task<ActionResult<OrderProductDto>> Update([FromRoute] Guid orderProductId, OrderProductRequest request)
    {
        var dto = await orderProductService.UpdateAsync(orderProductId, request);

        if (dto == null)
            return NotFound();
        
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<OrderProductDto>> Add([FromRoute] Guid orderId, OrderProductRequest request)
    {
        var dto = await orderProductService.CreateAsync(orderId, request);

        return CreatedAtAction(nameof(Add), dto);
    }

    [HttpDelete("{orderProductId}")]
    public async Task<IActionResult> Delete([FromRoute] Guid orderProductId)
    {
        var success = await orderProductService.TryDeleteAsync(orderProductId);

        if (!success)
            return NotFound();

        return NoContent();
    }
}