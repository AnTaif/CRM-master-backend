namespace MasterCRM.Application.Services.Orders.History;

public interface IOrderHistoryService
{
    public Task<IEnumerable<OrderHistoryDto>> GetOrderHistoryAsync(Guid orderId);
}

public record OrderHistoryDto(string Change, string Type, DateTime Date);