using MasterCRM.Application.Services.Websites.Constructor.Responses;
using MasterCRM.Domain.Entities.Websites;
using MasterCRM.Domain.Enums;

namespace MasterCRM.Application.MapExtensions;

public static class ConstructorBlockExtensions
{
    public static BlockDto ToDto(this ConstructorBlock block)
    {
        var blockDto = new BlockDto
        {
            Id = block.Id,
            BlockType = block.GetBlockType().ToString(),
            Title = block.Title,
            Order = block.Order,
            Properties = block.ToPropertiesDto()
        };

        return blockDto;
    }

    public static BlockType GetBlockType(this ConstructorBlock block)
    {
        return block switch
        {
            HeaderBlock => BlockType.Header,
            TextBlock => BlockType.Text,
            H1Block => BlockType.H1,
            CatalogBlock => BlockType.Catalog,
            MultipleTextBlock => BlockType.MultipleText,
            FooterBlock => BlockType.Footer,
            _ => throw new ArgumentException("Unknown block type", nameof(block))
        };
    }

    public static BlockPropertiesDto ToPropertiesDto(this ConstructorBlock block)
    {
        return block switch
        {
            HeaderBlock headerBlock => new BlockPropertiesDto
            {
                Type = headerBlock.Type
            },
            TextBlock textBlock => new BlockPropertiesDto
            {
                Text = textBlock.Text
            },
            H1Block h1Block => new BlockPropertiesDto
            {
                H1Text = h1Block.H1Text,
                PText = h1Block.PText,
                ImageUrl = h1Block.ImageUrl
            },
            CatalogBlock catalogBlock => new BlockPropertiesDto
            {
                Type = catalogBlock.Type
            },
            MultipleTextBlock multipleTextBlock => new BlockPropertiesDto
            {
                TextSections = new Dictionary<string, string>(multipleTextBlock.TextSections)
            },
            FooterBlock footerBlock => new BlockPropertiesDto
            {
                Type = footerBlock.Type
            },
            _ => throw new ArgumentException("Unknown block type", nameof(block))
        };
    }
}