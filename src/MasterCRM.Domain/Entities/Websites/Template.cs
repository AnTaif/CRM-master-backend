using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Websites;

public class Template : BaseEntity<int>
{
    public string Title { get; init; }
    
    public List<Style> GlobalStyles { get; init; }
    
    public List<ConstructorBlock> Components { get; init; }
    
    // TODO: order/product sections
    // public ConstructorBlock OrderSection { get; init; }
    //
    // public ConstructorBlock ProductCard { get; init; }
}