using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities;

public class OrderProduct : BaseEntity<Guid>
{
    public Guid ProductId { get; init; }
    public virtual Product Product { get; init; }
    
    /// <summary>
    /// Quantity of the product in the order
    /// </summary>
    public int Quantity { get; init; }
    
    /// <summary>
    /// Price of one unit of the product
    /// </summary>
    public double UnitPrice { get; init; }
}