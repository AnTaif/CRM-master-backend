using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.Services.Orders.History;

public class OrderHistoryService(IOrderHistoryRepository historyRepository) : IOrderHistoryService
{
    public async Task<IEnumerable<OrderHistoryDto>> GetOrderHistoryAsync(Guid orderId)
    {
        var history = await historyRepository
            .GetAllByPredicateAsync(historyItem => historyItem.OrderId == orderId);

        var historyList = history.ToList();
        return historyList.Select(orderHistory =>
            new OrderHistoryDto(orderHistory.Change, orderHistory.Type, orderHistory.Date));
    }
}