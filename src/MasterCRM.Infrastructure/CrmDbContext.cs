using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;
using MasterCRM.Domain.Entities.Products;
using MasterCRM.Domain.Entities.Websites;
using MasterCRM.Infrastructure.FileStorages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MasterCRM.Infrastructure;

public class CrmDbContext : IdentityDbContext<Master>
{
    private readonly string uploadUrl;
    
    public DbSet<Master> Masters { get; set; } = null!; // Identity model
    
    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<ProductPhoto> ProductPhotos { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<OrderHistory> OrderHistories { get; set; } = null!;

    public DbSet<Client> Clients { get; set; } = null!;
    
    public DbSet<Stage> Stages { get; set; } = null!;

    public DbSet<OrderProduct> OrderProducts { get; set; } = null!;

    public DbSet<Website> Websites { get; set; } = null!;
    
    public DbSet<Template> Templates { get; set; } = null!;

    public DbSet<ConstructorBlock> ConstructorBlocks { get; set; } = null!;

    public DbSet<GlobalStyles> GlobalStyles { get; set; } = null!;

    public CrmDbContext(IOptions<UploadsSettings> uploadsSettings, DbContextOptions<CrmDbContext> options) : base(options)
    {
        Database.EnsureCreated();
        uploadUrl = uploadsSettings.Value.UploadsUrl;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Website>()
            .HasIndex(w => w.AddressName)
            .IsUnique();
        
        modelBuilder.Entity<ConstructorBlock>()
            .HasDiscriminator<string>("BlockType")
            .HasValue<HeaderBlock>("Header")
            .HasValue<TextBlock>("Text")
            .HasValue<H1Block>("H1")
            .HasValue<CatalogBlock>("Catalog")
            .HasValue<FooterBlock>("Footer");
        
        modelBuilder.Entity<Template>()
            .HasData(
                new Template
                {
                    Id = 1,
                    Title = "Первый шаблон"
                },
                new Template
                {
                    Id = 2,
                    Title = "Второй шаблон"
                });

        modelBuilder.Entity<GlobalStyles>()
            .HasData(
                new GlobalStyles
                {
                    TemplateId = 1,
                    WebsiteId = null,
                    FontFamily = "Arial",
                    BackgroundColor = "#00ff00",
                    H1Color = "#f00000",
                    PColor = "#00f000",
                    ButtonColor = "#00000f"
                },
                new GlobalStyles
                {
                    TemplateId = 2,
                    WebsiteId = null,
                    FontFamily = "Arial",
                    BackgroundColor = "#ffffff",
                    H1Color = "#f00000",
                    PColor = "#00f000",
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
                },
                new HeaderBlock
                {
                    TemplateId = 2,
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
                    ImageUrl = $"{uploadUrl}/templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png"
                },
                new H1Block
                {
                    TemplateId = 2,
                    Order = 1,
                    Title = "",
                    H1Text = "H1 text",
                    PText =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in.",
                    ImageUrl = $"{uploadUrl}/templates/b655a1db-18cb-47cb-8939-7e2e5f6116d4.png"
                });
        
        modelBuilder.Entity<CatalogBlock>()
            .HasData(
                new CatalogBlock
                {
                    TemplateId = 1,
                    Order = 2,
                    Title = "Каталог",
                    Type = 0
                },
                new CatalogBlock
                {
                    TemplateId = 2,
                    Order = 2,
                    Title = "Каталог",
                    Type = 0
                });
        
        modelBuilder.Entity<TextBlock>()
            .HasData(
                new TextBlock
                {
                    TemplateId = 1,
                    Order = 4,
                    Title = "Подробнее о нас",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl."
                },
                new TextBlock
                {
                    TemplateId = 2,
                    Order = 4,
                    Title = "Подробнее о нас",
                    Text =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl."
                });

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
                },
                new FooterBlock
                {
                    TemplateId = 2,
                    Order = 5,
                    Title = "Свяжитесь со мной",
                    Type = 0
                });
        
        base.OnModelCreating(modelBuilder);
    }
}