using MasterCRM.Domain.Common;
using MasterCRM.Domain.Enums;

namespace MasterCRM.Domain.Entities;

public class Order : BaseEntity<Guid>
{
    public required string MasterId { get; set; }
    
    public string Name { get; set; } = null!;

    public required Guid ClientId { get; set; }
    public virtual Client Client { get; set; } = null!;

    public string Address { get; set; } = null!;
        
    public Guid StageId { get; set; }
    public virtual Stage Stage { get; set; } = null!;
    
    public required double TotalAmount { get; set; }
    
    public string Comment { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }

    public bool IsActive { get; private set; } = true;
    
    public virtual List<OrderProduct> OrderProducts { get; set; } = null!;
    
    public virtual List<OrderHistory> History { get; set; } = null!;
}