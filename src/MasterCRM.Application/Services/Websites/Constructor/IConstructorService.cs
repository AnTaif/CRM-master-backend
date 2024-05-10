using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.Services.Websites.Constructor;

public interface IConstructorService
{
    public Task<IEnumerable<BlockDto>> GetMainSection(string masterid, Guid websiteId);

    // public Task GetOrderRegistrationSection(string masterId, Guid websiteId);
    //
    // public Task GetProductCardSection(string masterId, Guid websiteId);
}

public record BlockDto
{
    public required Guid Id { get; init; }
    
    public required BlockType BlockType { get; init; }
    
    public required short Order { get; init; }
    
    public string? Text { get; init; }
    
    public string? H1Text { get; init; }
    
    public string? PText { get; init; }
    
    public string? ImageUrl { get; init; }
    
    public int? Type { get; init; }
}

public record ConstructorDto()
{
    public required Guid websiteId { get; init; }
    
    public required string Title { get; init; }
    
    
}