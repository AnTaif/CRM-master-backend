using MasterCRM.Domain.Common;
using MasterCRM.Domain.Enums;

namespace MasterCRM.Domain.Entities;

public class Order : BaseEntity<Guid>
{
    public required Guid MasterId { get; init; }
    //public virtual Master Master { get; init; }
    
    public virtual List<OrderProduct> OrderProducts { get; init; } = null!;

    public required Guid CustomerId { get; init; }
    
    public required int TotalAmount { get; init; }

    public ProcessingStage ProcessingStage { get; init; } = ProcessingStage.Registration;
    
    public string DeliveryAddress { get; init; }
    
    public string PostalCode { get; init; }
    
    public string Requirements { get; init; }
    
    public DateTime CreatedAt { get; init; }
}