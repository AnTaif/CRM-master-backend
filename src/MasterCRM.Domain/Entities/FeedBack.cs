using MasterCRM.Domain.Common;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Domain.Entities;

public class FeedBack : IEntity<Guid>
{
    public new Guid Id { get; init; }
    
    public Guid MasterId { get; init; }
    //public virtual Master Master { get; init; }
    
    public string Message { get; init; }
    
    public int ServiceAssessment { get; init; }
}