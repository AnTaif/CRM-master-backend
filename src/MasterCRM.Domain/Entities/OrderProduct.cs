using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities;

public class OrderProduct : BaseEntity<Guid>
{
    public Guid ProductId { get; init; }
    //public virtual Product Product { get; init; }
    
    public Guid OrderId { get; init; }
    //public virtual Order Order { get; init; }
    
    public int Quantity { get; init; }
    
    public double UnitPrice { get; init; }
}