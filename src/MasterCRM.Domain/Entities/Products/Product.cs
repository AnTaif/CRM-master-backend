using MasterCRM.Domain.Common;
using MasterCRM.Domain.Enums;

namespace MasterCRM.Domain.Entities.Products;

public class Product : BaseEntity<Guid>
{
    public string MasterId { get; set; } = null!;
    //public virtual Master Master { get; init; } 
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string? Dimensions { get; set; }
    
    public Material Material { get; set; }
    
    public double Price { get; set; }
    
    public DateTime CreationDate { get; set; }

    public bool IsVisible { get; set; } = true;

    public virtual List<ProductPhoto> Photos { get; set; } = new();

    public Product(string masterId, string name, string description, string dimensions, Material material, double price)
    {
        Id = Guid.NewGuid();
        MasterId = masterId;
        Name = name;
        Description = description;
        Dimensions = dimensions;
        Material = material;
        Price = price;
        CreationDate = DateTime.UtcNow;
    }

    public void Update(string? name, string? description, double? price, string? materialStr, string? dimensions)
    {
        if (name != null)
            Name = name;
        if (description != null)
            Description = description;
        if (price != null)
            Price = (double)price;
        if (materialStr != null)
            Material = Enum.Parse<Material>(materialStr);
        if (dimensions != null)
            Dimensions = dimensions;
    }

    public void ChangeVisibility() => IsVisible = !IsVisible;
}