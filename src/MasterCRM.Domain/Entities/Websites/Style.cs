using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Websites;

public class Style : BaseEntity<Guid>
{
    /// <summary>
    /// Html element to which style properties should be applied
    /// </summary>
    /// <example>body, h1, p, button</example>
    public string Element { get; }

    /// <summary>
    /// Css style properties
    /// </summary>
    /// <example>{ "color": "#8A2BE2"}, {"background-color": "#FFE4E1"}</example>
    public Dictionary<string, string> Properties { get; set; }
    
    public Style() { }

    public Style(string element, Dictionary<string, string> properties)
    {
        Element = element;
        Properties = properties;
    }
}