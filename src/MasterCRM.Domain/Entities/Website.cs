using MasterCRM.Domain.Common;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Domain.Entities;

public class Website : IEntity<Guid>
{
    public new Guid Id { get; init; }
    
    public string Title { get; init; }
    
    public string Domain { get; init; }
}