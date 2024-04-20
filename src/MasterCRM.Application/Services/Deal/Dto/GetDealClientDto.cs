namespace MasterCRM.Application.Services.Deal.Dto;

public record GetDealClientDto
{
    public required string FullName { get; init; }
    
    public required string Email { get; init; }
    
    public required string? Phone { get; init; }
    
    public required string Address { get; init; }
    
    public required string PostIndex { get; init; }
}