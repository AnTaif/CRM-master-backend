using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.Services.Websites.Templates.Responses;

public record TemplateDto
{
    public required int Id { get; init; }
    
    public string Title { get; init; }
    
    //TODO: change to constructorBlock's dtos
    public required List<ConstructorBlock> Components { get; init; }
}