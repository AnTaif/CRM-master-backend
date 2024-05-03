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
    
    public int? VkId { get; set; }

    public void Update(string? fullname, string? phone, string? vkLink, string? telegramLink)
    {
        if (fullname != null)
            SetFullName(fullname);
        if (phone != null)
            PhoneNumber = phone;
        if (vkLink != null)
            VkLink = vkLink;
        if (telegramLink != null)
            TelegramLink = telegramLink;
    }
    
    public void SetFullName(string fullname)
    {
        var names = fullname.Split();
        
        LastName = names[0];
        FirstName = names[1];
        MiddleName = names.Length > 2 ? names[2] : null;
    }

    public string GetFullName()
    {
        var fullName = $"{LastName} {FirstName}";
        if (!string.IsNullOrEmpty(MiddleName))
            fullName += $" {MiddleName}";
    
        return fullName;
    }
}