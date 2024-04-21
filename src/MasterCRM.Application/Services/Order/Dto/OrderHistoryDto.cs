namespace MasterCRM.Application.Services.Order.Dto;

public record OrderHistoryDto
{
    public required Guid Id { get; init; }
    
    public required string Change { get; init; }
    
    public required string Type { get; init; }
    
    public required string Stage { get; init; }
    
    public required DateTime Date { get; init; }
}