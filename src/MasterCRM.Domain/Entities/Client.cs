using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities;

public class Client : BaseEntity<Guid>
{
    public string MasterId { get; init; }
    //public virtual Master Master { get; init; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    
    public string? MiddleName { get; set; }

    public string Email { get; set; } = null!;
    
    public string Phone { get; set; } = null!;
    
    public DateTime LastOrderDate { get; set; }

    public Client()
    {
        Id = Guid.NewGuid();
    }

    public Client(string masterId, string fullname, string email, string phone)
    {
        Id = Guid.NewGuid();
        MasterId = masterId;
        SetFullName(fullname);
        Email = email;
        Phone = phone;
        LastOrderDate = DateTime.UtcNow;
    }

    public void Update(string? fullName, string? email, string? phone)
    {
        if (fullName != null)
            SetFullName(fullName);
        if (email != null)
            Email = email;
        if (phone != null)
            Phone = phone;
    }

    public string GetFullName()
    {
        var fullName = $"{LastName} {FirstName}";
        if (!string.IsNullOrEmpty(MiddleName))
            fullName += $" {MiddleName}";
    
        return fullName;
    }

    public void SetFullName(string fullname)
    {
        var names = fullname.Split();
        
        LastName = names[0];
        FirstName = names[1];
        MiddleName = names.Length > 2 ? names[2] : null;
    }
}