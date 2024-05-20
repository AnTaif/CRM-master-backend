using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Websites;

public class ConstructorBlock : BaseEntity<Guid>
{
    public new Guid Id { get; init; } = Guid.NewGuid();

    public string Title { get; init; } = null!;
    
    public short Order { get; init; }
    
    public int? TemplateId { get; init; }
    
    public Guid? WebsiteId { get; init; }
}

public class HeaderBlock : ConstructorBlock
{
    public int Type { get; set; } = 0;
}

public class TextBlock : ConstructorBlock
{
    public string Text { get; set; } = null!;
}

public class MultipleTextBlock : ConstructorBlock
{
    public IEnumerable<TextSection> TextSections { get; set; } = null!;
}

public class TextSection(string title, string text, Guid multipleTextBlockId) : BaseEntity<Guid>
{
    public new Guid Id { get; set; } = Guid.NewGuid();
    
    public string Title { get; set; } = title;

    public string Text { get; set; } = text;

    public Guid MultipleTextBlockId { get; set; } = multipleTextBlockId;
}

public class H1Block : ConstructorBlock
{
    public string H1Text { get; set; } = null!;

    public string? PText { get; set; }
    
    public string ImageUrl { get; set; } = null!;
}

public class CatalogBlock : ConstructorBlock
{
    public int Type { get; set; } = 0;
}

public class FooterBlock : ConstructorBlock
{
    public int Type { get; set; } = 0;
}