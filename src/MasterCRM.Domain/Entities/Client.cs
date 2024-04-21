using MasterCRM.Domain.Common;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Domain.Entities;

public class Client : IEntity<Guid>
{
    public new Guid Id { get; init; }
    
    public Guid MasterId { get; init; }
    //public virtual Master Master { get; init; }
    
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public string? MiddleName { get; init; }
    
    public string Email { get; init; }
    
    public string Phone { get; init; }
}