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

    public virtual List<ProductPhoto> Photos { get; set; } = null!;
}