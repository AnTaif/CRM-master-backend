using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities;

public class Master : BaseEntity<Guid>
{
    public virtual List<Deal> Orders { get; init; }
    public virtual List<Client> Customers { get; init; }
    public virtual List<Product> Products { get; init; }
    
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public string? MiddleName { get; init; }
    
    public Guid WebsiteId { get; init; }
    
    public string Email { get; init; }
    
    public string PasswordHash { get; init; }
    
    public virtual List<FeedBack> FeedBacks { get; init; }
}