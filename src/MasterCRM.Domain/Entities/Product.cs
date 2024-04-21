using MasterCRM.Domain.Common;
using MasterCRM.Domain.Enums;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Domain.Entities;

public class Product : IEntity<Guid>
{
    public new Guid Id { get; init; }
    
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