using MasterCRM.Application.Services.Websites.Constructor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Websites;

[ApiController]
[Authorize]
[Route("websites/{websiteId}/constructor")]
public class ConstructorController(IConstructorService constructorService) : ControllerBase
{
    [HttpGet("main")]
    public async Task GetMainSection()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("order")]
    public async Task GetOrderRegistrationSection()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("product")]
    public async Task GetProductCardSection()
    {
        throw new NotImplementedException();
    }
}