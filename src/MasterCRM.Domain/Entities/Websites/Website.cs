using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Websites;

public class Website : BaseEntity<Guid>
{
    public string Title { get; init; }
    
    public string Domain { get; init; }
}