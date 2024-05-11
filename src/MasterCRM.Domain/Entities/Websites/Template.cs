using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Websites;

public class Template : BaseEntity<int>
{
    public string Title { get; init; }
    
    public virtual List<Style> GlobalStyles { get; init; }
    
    public virtual List<ConstructorBlock> Components { get; init; }
    
    // TODO: order/product sections
    // public ConstructorBlock OrderSection { get; init; }
    //
    // public ConstructorBlock ProductCard { get; init; }
}