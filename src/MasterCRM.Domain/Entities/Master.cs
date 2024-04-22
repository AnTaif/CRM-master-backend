using Microsoft.AspNetCore.Identity;

namespace MasterCRM.Domain.Entities;

public class Master : IdentityUser
{
    public string FirstName { get;  set; } = null!;

    public string LastName { get;  set; } = null!;

    public string? MiddleName { get;  set; }
    
    public Guid WebsiteId { get; init; }
    //public virtual Website { get; init; }
    
    // public string Email { get; init; }
    //
    // public string PasswordHash { get; init; }
    
    // public virtual List<Deal> Deals { get; init; } = null!;
    // public virtual List<Client> Customers { get; init; } = null!;
    // public virtual List<Product> Products { get; init; } = null!;
    //
    // public virtual List<FeedBack> FeedBacks { get; init; } = null!;
    
    public string? VkLink { get;  set; }
    
    public string? TelegramLink { get;  set; }

    public string GetFullName()
    {
        var fullName = $"{LastName} {FirstName}";
        if (!string.IsNullOrEmpty(MiddleName))
            fullName += $" {MiddleName}";
    
        return fullName;
    }
}