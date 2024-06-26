using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Orders;

public class Order : BaseEntity<Guid>
{
    public required string MasterId { get; set; }
    public Master Master { get; set; } = null!;
    
    //TODO: fix name changing when client changed
    public string Name { get; set; } = null!;

    public Guid ClientId { get; set; }
    public virtual Client Client { get; set; } = null!;

    public string Address { get; set; } = null!;
        
    public Guid StageId { get; set; }
    public virtual Stage Stage { get; set; } = null!;
    
    public double TotalAmount { get; set; }
    
    public bool IsCalculationAutomated { get; set; }
    
    public string Comment { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }

    public bool IsActive { get; private set; } = true;
    
    public virtual List<OrderProduct> OrderProducts { get; set; } = null!;
    
    public virtual List<OrderHistory> History { get; set; } = null!;
}