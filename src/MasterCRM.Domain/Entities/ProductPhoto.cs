using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities;

public class ProductPhoto : BaseEntity<Guid>
{
    public string Url { get; set; } = null!;
    
    public string? Extension { get; set; }
}