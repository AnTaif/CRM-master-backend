using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Websites;

public class Style : BaseEntity<Guid>
{
    /// <summary>
    /// Html element to which style properties should be applied
    /// </summary>
    /// <example>body, h1, p, button</example>
    public string Element { get; init; } = null!;

    /// <summary>
    /// Css style properties
    /// </summary>
    /// <example>{ "color": "#8A2BE2"}, {"background-color": "#FFE4E1"}</example>
    public Dictionary<string, string> Properties { get; set; } = null!;

    public int? TemplateId { get; init; }
    
    public Guid? WebsiteId { get; init; }

    public Style()
    {
        Id = Guid.NewGuid();
    }

    public Style(string element, Dictionary<string, string> properties)
    {
        Id = Guid.NewGuid();
        Element = element;
        Properties = properties;
    }
}