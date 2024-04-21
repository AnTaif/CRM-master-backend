using MasterCRM.Domain.Common;
using MasterCRM.Domain.Enums;

namespace MasterCRM.Domain.Entities;

public class Product : BaseEntity<Guid>
{
    public Guid MasterId { get; init; } 
    //public virtual Master Master { get; init; } 
    
    public string Name { get; init; }
    
    public string Description { get; init; }
    
    public string? Dimensions { get; init; }
    
    public Material Material { get; init; }
    
    public double Price { get; init; }
    
    public int StockQuantity { get; init; }
    
    public DateTime CreationDate { get; init; }
    
    public string ImageSrc { get; init; }
}