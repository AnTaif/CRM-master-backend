using MasterCRM.Domain.Common;
using MasterCRM.Domain.Entities.Orders;

namespace MasterCRM.Domain.Entities;

public class Client : BaseEntity<Guid>
{
    public string MasterId { get; init; } = null!;
    public virtual Master Master { get; init; } = null!;
    
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    
    public string? MiddleName { get; set; }

    public string Email { get; set; } = null!;
    
    public string Phone { get; set; } = null!;

    public virtual List<Order> Orders { get; set; } = null!;
    
    public DateTime GetLastOrderDate() => Orders.Max(order => order.CreatedAt);
    
    public string Initials => GetInitials();

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
    }

    public void Update(string? fullName, string? email, string? phone)
    {
        if (fullName != null)
        {
            SetFullName(fullName);
            UpdateOrdersNames();
        }
        if (email != null)
            Email = email;
        if (phone != null)
            Phone = phone;
    }

    private void UpdateOrdersNames()
    {
        foreach (var order in Orders)
            order.Name = GetInitials();
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

    public string GetInitials() => 
        $"{LastName} {FirstName[0]}." + (MiddleName != null ? $"{MiddleName[0]}." : "");

    public static string GetInitials(string fullname)
    {
        var names = fullname.Split();
        return $"{names[0]} {names[1][0]}." + (names.Length > 2 ? $"{names[2][0]}." : "");
    }
}