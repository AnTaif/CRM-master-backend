namespace MasterCRM.Application.Services.Orders.Responses;

/// <summary>
/// Represents a response for list of orders.
/// </summary>
public class GetOrderItemResponse
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string Stage { get; init; }
    
    public required double TotalAmount { get; init; }
    
    public required string Comment { get; init; }
    
    public required string Address { get; init; }
    
    public required DateTime Date { get; init; }
    
    public required OrderClientDto Client { get; init; }
}