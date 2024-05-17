namespace MasterCRM.Application.Services.Orders.Responses;

public record GetOrdersResponse(int Count, IEnumerable<GetOrderItemResponse> Orders);