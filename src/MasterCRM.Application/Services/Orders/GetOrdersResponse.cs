using MasterCRM.Application.Services.Orders.Responses;

namespace MasterCRM.Application.Services.Orders;

public record GetOrdersResponse(int Count, IEnumerable<GetOrderItemResponse> Orders);