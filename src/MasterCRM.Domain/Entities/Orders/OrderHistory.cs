using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Orders;

public class OrderHistory : BaseEntity<Guid>
{
    public Guid OrderId { get; init; }
    
    public string Change { get; init; } = null!;
    
    public string Type { get; init; } = null!;
    
    public DateTime Date { get; init; }

    public OrderHistory()
    {
    }
    
    public OrderHistory(Guid orderId, string change, string type)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        Change = change;
        Type = type;
        Date = DateTime.UtcNow;
    }
}