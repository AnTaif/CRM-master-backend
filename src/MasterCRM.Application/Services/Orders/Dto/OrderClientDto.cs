namespace MasterCRM.Application.Services.Orders.Dto;

public record OrderClientDto
{
    public required string FullName { get; init; }
    
    public required string Email { get; init; }
    
    public required string Phone { get; init; }
}