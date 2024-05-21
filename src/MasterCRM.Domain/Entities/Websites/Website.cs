using System.ComponentModel.DataAnnotations.Schema;
using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Websites;

public class Website : BaseEntity<Guid>
{
    public required string Title { get; set; }
    
    public required string AddressName { get; set; }
    
    public required string OwnerId { get; init; }
    
    [ForeignKey("OwnerId")]
    public virtual Master Master { get; init; } = null!;
    
    public int? TemplateId { get; set; }

    public GlobalStyles? GlobalStyles { get; set; }

    public List<ConstructorBlock>? Components { get; set; }
    
    // TODO: order/product sections
    // public ConstructorBlock OrderSection { get; set; }
    //
    // public ConstructorBlock ProductCard { get; set; }

    // TODO: when updating blocks, this string must be changed
    public string GetWebsite() => "website is not ready";
}