using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Websites;

public class GlobalStyles : BaseEntity<Guid>
{
    public new Guid Id { get; init; } = Guid.NewGuid();
    
    public int? TemplateId { get; init; }
    
    public Guid? WebsiteId { get; init; }
   
    public string FontFamily { get; set; } = null!;

    public string BackgroundColor { get; set; } = null!;

    public string H1Color { get; set; } = null!;

    public string PColor { get; set; } = null!;

    public string ButtonColor { get; set; } = null!;
}