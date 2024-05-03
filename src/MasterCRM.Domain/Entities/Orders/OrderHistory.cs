using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Orders;

public class OrderHistory : BaseEntity<Guid>
{
    public Guid OrderId { get; init; }
    
    public string Change { get; init; } = null!;
    
    public string Type { get; init; } = null!;
    
    public DateTime Date { get; init; }
}