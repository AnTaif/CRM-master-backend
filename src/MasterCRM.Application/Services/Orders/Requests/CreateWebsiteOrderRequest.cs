using MasterCRM.Application.Services.Orders.Products.Requests;
using MasterCRM.Application.Services.Orders.Responses;

namespace MasterCRM.Application.Services.Orders.Requests;

public record CreateWebsiteOrderRequest
{
    public required OrderClientDto Client { get; init; }
    
    public required string Comment { get; init; }
    
    public required string Address { get; init; }
    
    public required IEnumerable<OrderProductRequest> Products { get; init; }
}