using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities;

public class Client : BaseEntity<Guid>
{
    public string MasterId { get; init; } = null!;
    //public virtual Master Master { get; init; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    
    public string? MiddleName { get; set; }

    public string Email { get; set; } = null!;
    
    public string Phone { get; set; }
    
    public string GetFullName()
    {
        var fullName = $"{LastName} {FirstName}";
        if (!string.IsNullOrEmpty(MiddleName))
            fullName += $" {MiddleName}";
    
        return fullName;
    }
}