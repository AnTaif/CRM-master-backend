using MasterCRM.Domain.Common;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Domain.Entities;

public class DealProduct : IEntity<Guid>
{
    public new Guid Id { get; init; }
    
    public Guid ProductId { get; init; }
    public virtual Product Product { get; init; }
    
    public Guid DealId { get; init; }
    public virtual Deal Deal { get; init; }
    
    public int Quantity { get; init; }
    
    public double UnitPrice { get; init; }
}