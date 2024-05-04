using System.Security.Claims;
using MasterCRM.Application.Services.Orders;
using MasterCRM.Application.Services.Orders.Dto;
using MasterCRM.Application.Services.Orders.Requests;
using MasterCRM.Application.Services.Orders.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Orders;

[ApiController]
[Authorize]
[Route("orders")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<GetOrderItemResponse>>> GetAllByMaster()
    // {
    //     var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    //     
    //     return Ok(await orderService.GetAllByMasterAsync(masterId));
    // }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetOrderItemResponse>>> GetWithStageByMaster([FromQuery] short? tab)
    {
        var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        if (tab == null)
            return Ok(await orderService.GetAllByMasterAsync(masterId));
        
        return Ok(await orderService.GetWithStageByMasterAsync(masterId, (short)tab));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetOrderById([FromRoute] Guid id)
    {
        var order = await orderService.GetOrderByIdAsync(id);
        
        if (order is null)
            return NotFound();
        
        return Ok(order);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateOrder(CreateOrderRequest request)
    {
        var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        var orderId = await orderService.CreateOrderAsync(masterId, request);
        
        return Ok(orderId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<OrderDto>> UpdateOrder([FromRoute] Guid id, ChangeOrderRequest request)
    {
        var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var response = await orderService.ChangeOrderAsync(masterId, id, request);

        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder([FromRoute] Guid id)
    {
        var result = await orderService.TryDeleteOrderAsync(id);
        
        if (!result)
            return NotFound();
        
        return NoContent();
    }
}