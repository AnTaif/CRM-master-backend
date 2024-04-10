using MasterCRM.Domain.Common;
using MasterCRM.Domain.Enums;

namespace MasterCRM.Domain.Entities;

public class Order : BaseEntity<Guid>
{
    public Guid MasterId { get; init; }
    public virtual Master Master { get; init; }
    
    public virtual List<OrderProduct> OrderProducts { get; init; }
    
    public Guid CustomerId { get; init; }
    
    public int TotalAmount { get; init; }
    
    public ProcessingStage ProcessingStage { get; init; }
    
    public string DeliveryAddress { get; init; }
    
    public string PostalCode { get; init; }
    
    public string OrderRequirements { get; init; }
    
    public DateTime CreatedAt { get; init; }
}