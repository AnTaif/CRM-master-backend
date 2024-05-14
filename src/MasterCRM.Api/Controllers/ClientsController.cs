using System.Security.Claims;
using MasterCRM.Application.Services.Clients;
using MasterCRM.Application.Services.Clients.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers;

[ApiController]
[Authorize]
[Route("clients")]
public class ClientsController(IClientService clientService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ClientItemResponse>> GetByCurrentUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        var response = await clientService.GetByMasterAsync(userId);
        
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var response = await clientService.GetByIdAsync(id);
        
        if (response == null)
            return NotFound();
        
        return Ok(response);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ChangeClientRequest request)
    {
        var result = await clientService.TryChangeAsync(id, request);
        
        if (!result)
            return BadRequest();
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await clientService.TryDeleteAsync(id);
        
        if (!result)
            return BadRequest();
        
        return NoContent();
    }
}