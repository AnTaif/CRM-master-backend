namespace MasterCRM.Application.Services.Deal.Dto;

public record DealHistoryDto
{
    public required Guid Id { get; init; }
    
    public required string Change { get; init; }
    
    public required string Type { get; init; }
    
    public required string Stage { get; init; }
    
    public required DateTime Date { get; init; }
}