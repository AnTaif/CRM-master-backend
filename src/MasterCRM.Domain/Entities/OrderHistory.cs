using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities;

public class OrderHistory : BaseEntity<Guid>
{
    public string Change { get; init; }
    
    public string Type { get; init; }
    
    public string Stage { get; init; }
    
    public DateTime Date { get; init; }
}