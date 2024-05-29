using MasterCRM.Domain.Entities.Websites;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure.Data;

public static class DataSeeder
{
    public static void Seed(ModelBuilder modelBuilder, string uploadUrl)
    {
        SeedTemplates(modelBuilder, uploadUrl);
    }

    private static void SeedTemplates(ModelBuilder modelBuilder, string uploadUrl)
    {
        modelBuilder.Entity<Template>()
            .HasData(
                new Template
                {
                    Id = 1,
                    Title = "Первый шаблон"
                });

        modelBuilder.Entity<GlobalStyles>()
            .HasData(
                new GlobalStyles
                {
                    TemplateId = 1,
                    WebsiteId = null,
                    FontFamily = "Arial",
                    BackgroundColor = "#F0EEF0",
                    H1Color = "#FFFFFF",
                    PColor = "#FFFFFF",
                    ButtonColor = "#00000f"
                });

        modelBuilder.Entity<HeaderBlock>()
            .HasData(
                new HeaderBlock
                {
                    TemplateId = 1,
                    Order = 0,
                    Title = "",
                    Type = 0
                });
        
        modelBuilder.Entity<H1Block>()
            .HasData(
                new H1Block
                {
                    TemplateId = 1,
                    Order = 1,
                    Title = "",
                    H1Text = "Душевная мастерская",
                    PText = "Добро пожаловать в нашу handmade мастерскую, где мы создаем уникальные украшения вручную с любовью и вниманием к деталям. Каждый элемент, от колец до ожерелий, сделан из высококачественных материалов, чтобы подчеркнуть вашу индивидуальность и стиль.",
                    ImageUrl = $"{uploadUrl}templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png"
                });
        
        modelBuilder.Entity<CatalogBlock>()
            .HasData(
                new CatalogBlock
                {
                    TemplateId = 1,
                    Order = 2,
                    Title = "Каталог",
                    Type = 0
                });
        
        // modelBuilder.Entity<TextBlock>()
        //     .HasData(
        //         new TextBlock
        //         {
        //             TemplateId = 2,
        //             Order = 4,
        //             Title = "Подробнее о нас",
        //             Text =
        //                 "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl."
        //         });

        var multipleBlockId = Guid.NewGuid();
        modelBuilder.Entity<MultipleTextBlock>()
            .HasData(
                new MultipleTextBlock
                {
                    Id = multipleBlockId,
                    Title = "Преимущества",
                    Order = 3,
                    TemplateId = 1
                });

        modelBuilder.Entity<TextSection>()
            .HasData(
                new TextSection("Уникальность изделий", "Каждое украшение создается вручную, что гарантирует его неповторимость и эксклюзивность.", multipleBlockId),
                new TextSection("Творческий дизайн", "Наши мастера постоянно разрабатывают новые и оригинальные модели, чтобы вы всегда могли найти что-то свежее и стильное.", multipleBlockId),
                new TextSection("Высокое качество материалов", "Мы используем только проверенные и высококачественные материалы, обеспечивая долговечность и эстетичность каждого изделия.", multipleBlockId));
        
        modelBuilder.Entity<FooterBlock>()
            .HasData(
                new FooterBlock
                {
                    TemplateId = 1,
                    Order = 5,
                    Title = "Свяжитесь со мной",
                    Type = 0
                });
    }
}