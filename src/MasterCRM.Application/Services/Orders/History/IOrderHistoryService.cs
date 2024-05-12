using MasterCRM.Domain.Entities.Orders;

namespace MasterCRM.Application.Services.Orders.History;

public interface IOrderHistoryService
{
    public Task<IEnumerable<OrderHistoryDto>?> GetOrderHistoryAsync(string masterId, Guid orderId);

    public Task AddNewOrderHistoryAsync(Guid orderId, string orderName, DateTime date);

    public Task AddOrderChangedHistoryAsync(
        Guid id, double? totalAmount, string? comment, string? address, bool? isCalculationAutomated, DateTime date);

    public Task AddStageChangedHistoryAsync(Guid id, Stage prevStage, Stage nextStage, DateTime date);

    public Task AddClientChangedHistoryAsync(Guid id, string? fullname, string? email, string? phone, DateTime date);

    public Task AddOrderProductsChangedHistoryAsync(Guid id, IReadOnlyCollection<OrderProduct>? products, DateTime date);
}

public record OrderHistoryDto(string Type, string Change, DateTime Date);