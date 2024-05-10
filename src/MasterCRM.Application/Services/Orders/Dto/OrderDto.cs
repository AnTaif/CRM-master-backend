namespace MasterCRM.Application.Services.Orders.Dto;

public record OrderDto
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string Stage { get; init; }
    
    public required double TotalAmount { get; init; }
    
    public required bool IsCalculationAutomated { get; init; }
    
    public required string Comment { get; init; }
    
    public required string Address { get; init; }
    
    public required OrderClientDto Client { get; init; }
    
    public required IEnumerable<OrderProductDto> Products { get; init; }
}