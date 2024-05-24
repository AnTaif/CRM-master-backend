using MasterCRM.Application.Services.Websites.Templates;
using MasterCRM.Application.Services.Websites.Templates.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterCRM.Api.Controllers.Websites;

[ApiController]
[Authorize]
[Route("templates")]
public class TemplateController(ITemplateService templateService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TemplateDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTemplates()
    {
        var templateDtos = await templateService.GetTemplates();

        return Ok(templateDtos);
    }
}