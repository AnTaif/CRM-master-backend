using MasterCRM.Domain.Entities.Orders;
using MasterCRM.Domain.Exceptions;

namespace MasterCRM.Application.Services.Orders.History;

public class OrderHistoryService(IOrderHistoryRepository historyRepository, IOrderRepository orderRepository) : IOrderHistoryService
{
    public async Task<IEnumerable<OrderHistoryDto>?> GetOrderHistoryAsync(string masterId, Guid orderId)
    {
        var order = await orderRepository.GetByIdAsync(orderId);

        if (order == null)
            return null;

        if (order.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the order");
        
        var history = await historyRepository
            .GetAllByPredicateAsync(historyItem => historyItem.OrderId == orderId);
        
        var historyList = history.ToList();
        return historyList.Select(orderHistory =>
            new OrderHistoryDto(orderHistory.Type, orderHistory.Change, orderHistory.Date));
    }

    public async Task AddNewOrderHistoryAsync(Guid orderId, string orderName, DateTime date)
    {
        var historyItem = new OrderHistory
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            Change = $"Заказ {orderName}",
            Type = "Создан заказ",
            Date = date
        };
        
        await historyRepository.CreateAsync(historyItem);
    }
    
    public async Task AddOrderChangedHistoryAsync(
        Guid id, double? totalAmount, string? comment, string? address, bool? isCalculationAutomated, DateTime date)
    {
        if (totalAmount != null)
        {
            var historyItem = new OrderHistory
            {
                Id = Guid.NewGuid(),
                OrderId = id,
                Change = "Сумма",
                Type = "Данные заказа изменены",
                Date = date
            };
            await historyRepository.CreateAsync(historyItem);
        }
        if (comment != null)
        {
            var historyItem = new OrderHistory
            {
                Id = Guid.NewGuid(),
                OrderId = id,
                Change = "Комментарий",
                Type = "Данные заказа изменены",
                Date = date
            };
            await historyRepository.CreateAsync(historyItem);
        }
        if (address != null)
        {
            var historyItem = new OrderHistory
            {
                Id = Guid.NewGuid(),
                OrderId = id,
                Change = "Адрес доставки",
                Type = "Данные заказа изменены",
                Date = date
            };
            await historyRepository.CreateAsync(historyItem);
        }

        if (isCalculationAutomated != null)
            await AddCostCalculationChangedHistoryAsync(id, (bool)isCalculationAutomated, date);
    }
    
    public async Task AddStageChangedHistoryAsync(Guid id, Stage prevStage, Stage nextStage, DateTime date)
    {
        if (prevStage.Order == nextStage.Order)
            return;
        
        var historyItem = new OrderHistory
        {
            Id = Guid.NewGuid(),
            OrderId = id,
            Change = $"{prevStage.Name} -> {nextStage.Name}",
            Type = "Этап изменен",
            Date = date
        };
        await historyRepository.CreateAsync(historyItem);
    }
    
    public async Task AddClientChangedHistoryAsync(Guid id, string? fullname, string? email, string? phone, DateTime date)
    {
        if (fullname != null)
        {
            var historyItem = new OrderHistory
            {
                Id = Guid.NewGuid(),
                OrderId = id,
                Change = "ФИО",
                Type = "Данные клиента изменены",
                Date = date
            };
            await historyRepository.CreateAsync(historyItem);
        }
        if (email != null)
        {
            var historyItem = new OrderHistory
            {
                Id = Guid.NewGuid(),
                OrderId = id,
                Change = "Электронная почта",
                Type = "Данные клиента изменены",
                Date = date
            };
            await historyRepository.CreateAsync(historyItem);
        }
        if (phone != null)
        {
            var historyItem = new OrderHistory
            {
                Id = Guid.NewGuid(),
                OrderId = id,
                Change = "Телефон",
                Type = "Данные клиента изменены",
                Date = date
            };
            await historyRepository.CreateAsync(historyItem);
        }
    }
    
    public async Task AddOrderProductsChangedHistoryAsync(Guid id, IReadOnlyCollection<OrderProduct>? products, DateTime date)
    {
        if (products == null)
            return;
        
        var historyItem = new OrderHistory
        {
            Id = Guid.NewGuid(),
            OrderId = id,
            Change = $"{products.Count} {GetNounForm(products.Count)} на сумму {products.Sum(product => product.Quantity * product.UnitPrice)} \u20bd",
            Type = "Товары заказа изменены",
            Date = date
        };
        await historyRepository.CreateAsync(historyItem);
    }
    
    private static string GetNounForm(int number)
    {
        var lastDigit = number % 10;
        var lastTwoDigits = number % 100;

        if (lastTwoDigits is >= 11 and <= 19)
            return "позиций";

        switch (lastDigit)
        {
            case 1:
                return "позиция";
            case 2: case 3: case 4:
                return "позиции";
            default:
                return "позиций";
        }
    }
    
    private async Task AddCostCalculationChangedHistoryAsync(Guid orderId, bool isAutomatedNow, DateTime date)
    {
        var prev = isAutomatedNow ? "На основе стоимости товаров" : "Вручную";
        var next = isAutomatedNow ?  "Вручную" : "На основе стоимости товаров";
        var historyItem = new OrderHistory
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            Change = $"{prev} -> {next}",
            Type = "Изменен режим расчета суммы",
            Date = date
        };
        await historyRepository.CreateAsync(historyItem);
    }
}