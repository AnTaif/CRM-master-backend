using MasterCRM.Domain.Common;
using MasterCRM.Domain.Entities.Products;

namespace MasterCRM.Domain.Entities.Orders;

public class OrderProduct : BaseEntity<Guid>
{
    public Guid OrderId { get; init; }
    
    public Guid ProductId { get; set; }
    public virtual Product Product { get; init; } = null!;
    
    /// <summary>
    /// Quantity of the product in the order
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Price of one unit of the product
    /// </summary>
    public double UnitPrice { get; set; }

    public void Update(Guid productId, int quantity, double unitPrice)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}