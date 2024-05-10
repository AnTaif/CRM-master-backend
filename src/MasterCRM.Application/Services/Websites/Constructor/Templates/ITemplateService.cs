using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.Services.Websites.Constructor.Templates;

public interface ITemplateService
{
    public Task<IEnumerable<GetTemplatesResponse>> GetTemplates();
    
    public Task<TemplateDto> GetTemplate(int id);
}

public record GetTemplatesResponse(int Id, string Title);

public record TemplateDto
{
    public required int Id { get; init; }
    
    public string Title { get; init; }
    
    //TODO: change to constructorBlock's dtos
    public required List<ConstructorBlock> Components { get; init; }
}