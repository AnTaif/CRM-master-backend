using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Websites;

public class Template : BaseEntity<int>
{
    public string Title { get; init; } = null!;

    public GlobalStyles GlobalStyles { get; init; } = null!;

    public virtual List<ConstructorBlock> Components { get; init; } = null!;

    // TODO: order/product sections
    // public ConstructorBlock OrderSection { get; init; }
    //
    // public ConstructorBlock ProductCard { get; init; }
}