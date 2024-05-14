using System.Text;
using MasterCRM.Domain.Common;
using MasterCRM.Domain.Entities.Orders;

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
    
    public virtual List<Order> Orders { get; set; }
    
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
    
    public Client(string masterId, string fullname, string email, string phone, DateTime orderDate)
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

    public string GetInitials()
    {
        var initials = new StringBuilder();

        initials.Append(LastName);
        initials.Append($" {FirstName[0]}.");
        if (MiddleName != null)
            initials.Append($"{MiddleName[0]}.");
        return initials.ToString();
    }
}