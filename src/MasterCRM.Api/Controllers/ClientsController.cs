using System.Security.Claims;
using MasterCRM.Application.Services.Clients;
using MasterCRM.Application.Services.Clients.Requests;
using MasterCRM.Application.Services.Clients.Responses;
using MasterCRM.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers;

[ApiController]
[Authorize]
[Route("clients")]
public class ClientsController(IClientService clientService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ClientItemResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<ClientItemResponse>> GetByCurrentUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        
        var response = await clientService.GetByMasterAsync(userId);
        
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ClientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            
            var response = await clientService.GetByIdAsync(masterId, id);
            
            if (response == null)
                return NotFound("Client not found");
            
            return Ok(response);
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ChangeClientRequest request)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            
            var result = await clientService.TryChangeAsync(masterId, id, request);
            
            if (!result)
                return NotFound("Client not found");
            
            return NoContent();
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        try
        {
            var masterId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            
            var result = await clientService.TryDeleteAsync(masterId, id);
            
            if (!result)
                return NotFound("Client not found");
            
            return NoContent();
        }
        catch (ForbidException)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }
}