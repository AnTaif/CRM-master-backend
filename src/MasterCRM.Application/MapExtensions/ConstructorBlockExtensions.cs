using MasterCRM.Application.Services.Websites.Constructor.Responses;
using MasterCRM.Domain.Entities.Websites;
using MasterCRM.Domain.Enums;

namespace MasterCRM.Application.MapExtensions;

public static class ConstructorBlockExtensions
{
    public static BlockDto ToDto(this ConstructorBlock block)
    {
        return block switch
        {
            HeaderBlock headerBlock => new BlockDto
            {
                Id = headerBlock.Id,
                BlockType = BlockType.Header.ToString(),
                Order = headerBlock.Order,
                Properties = new Dictionary<string, string>
                {
                    {"type", headerBlock.Type.ToString()}
                }
            },
            TextBlock textBlock => new BlockDto
            {
                Id = textBlock.Id,
                BlockType = BlockType.Text.ToString(),
                Order = textBlock.Order,
                Properties = new Dictionary<string, string>()
                {
                    {"text", textBlock.Text}
                }
            },
            H1Block h1Block => new BlockDto
            {
                Id = h1Block.Id,
                BlockType = BlockType.H1.ToString(),
                Order = h1Block.Order,
                Properties = new Dictionary<string, string>
                {
                    {"h1Text", h1Block.H1Text},
                    {"pText", h1Block.PText ?? ""},
                    {"imageUrl", h1Block.ImageUrl}
                }
            },
            CatalogBlock catalogBlock => new BlockDto
            {
                Id = catalogBlock.Id,
                BlockType = BlockType.Catalog.ToString(),
                Order = catalogBlock.Order,
                Properties = new Dictionary<string, string>
                {
                    {"type", catalogBlock.Type.ToString()}
                }
            },
            FooterBlock footerBlock => new BlockDto
            {
                Id = footerBlock.Id,
                BlockType = BlockType.Footer.ToString(),
                Order = footerBlock.Order,
                Properties = new Dictionary<string, string>
                {
                    {"type", footerBlock.Type.ToString()}
                }
            },
            _ => throw new ArgumentException("Unknown block type", nameof(block))
        };
    }
}