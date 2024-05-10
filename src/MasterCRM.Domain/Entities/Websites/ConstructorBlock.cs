using MasterCRM.Domain.Common;

namespace MasterCRM.Domain.Entities.Websites;

public class ConstructorBlock : BaseEntity<Guid>
{
    public short Order { get; init; }
    
    //public string Styles { get; init; }
}

public class HeaderBlock : ConstructorBlock
{
    public int Type { get; set; } = 0;
}

public class TextBlock : ConstructorBlock
{
    public string Text { get; set; } = null!;
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

public enum BlockType
{
    Header = 0,
    Footer = 1,
    Text = 2,
    H1 = 3,
    Catalog = 4,
}

/*
foreach (var block in store.Blocks.OrderBy(b => b.Order))
{
    if (block is TextBlock textBlock)
    {
        htmlBuilder.Append($"<div><h2>{textBlock.Title}</h2><p>{textBlock.Text}</p></div>");
    }
    else if (block is ImageBlock imageBlock)
    {
        htmlBuilder.Append($"<div><h2>{imageBlock.Title}</h2><img src='{imageBlock.ImageUrl}' alt=''></div>");
    }
    else if (block is CatalogBlock catalogBlock)
    {
        htmlBuilder.Append($"<div><h2>{catalogBlock.Title}</h2><p>Catalog with style: {catalogBlock.CardStyle}</p></div>");
    }
}
*/