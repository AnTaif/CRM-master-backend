using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Websites;

public class FeedBack : BaseEntity<Guid>
{
    public Guid MasterId { get; init; }
    //public virtual Master Master { get; init; }
    
    public string Message { get; init; }
    
    public int ServiceAssessment { get; init; }
}