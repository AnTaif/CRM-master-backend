using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities;

public class DealProduct : BaseEntity<Guid>
{
    public Guid ProductId { get; init; }
    public virtual Product Product { get; init; }
    
    public Guid DealId { get; init; }
    public virtual Deal Deal { get; init; }
    
    public int Quantity { get; init; }
    
    public double UnitPrice { get; init; }
}