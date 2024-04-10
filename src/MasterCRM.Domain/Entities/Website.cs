using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities;

public class Website : BaseEntity<Guid>
{
    public string Title { get; init; }
    
    public string Domain { get; init; }
}