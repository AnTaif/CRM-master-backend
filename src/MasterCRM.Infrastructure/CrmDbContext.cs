using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;
using MasterCRM.Domain.Entities.Products;
using MasterCRM.Domain.Entities.Websites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure;

public class CrmDbContext : IdentityDbContext<Master>
{
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

    public DbSet<Style> Styles { get; set; } = null!;

    public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<Style>()
            .HasData(
                new Style
                {
                    TemplateId = 1,
                    Selector = "body",
                    Properties = new Dictionary<string, string>
                    {
                        {"background-color", "#100001"},
                        {"color", "#000011"}
                    } 
                },
                new Style
                {
                    TemplateId = 1,
                    Selector = "h1",
                    Properties = new Dictionary<string, string>
                    {
                        {"color", "#001100"}
                    } 
                },
                new Style
                {
                    TemplateId = 2,
                    Selector = "body",
                    Properties = new Dictionary<string, string>
                    {
                        {"background-color", "#000001"},
                        {"color", "#110011"}
                    } 
                },
                new Style
                {
                    TemplateId = 2,
                    Selector = "h1",
                    Properties = new Dictionary<string, string>
                    {
                        {"color", "#110000"}
                    } 
                });

        modelBuilder.Entity<HeaderBlock>()
            .HasData(
                new HeaderBlock
                {
                    TemplateId = 1,
                    Order = 0,
                    Type = 0
                },
                new HeaderBlock
                {
                    TemplateId = 2,
                    Order = 0,
                    Type = 0
                });
        
        modelBuilder.Entity<H1Block>()
            .HasData(
                new H1Block
                {
                    TemplateId = 1,
                    Order = 1,
                    H1Text = "H1 text",
                    PText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.",
                    ImageUrl = "http://localhost:8080/uploads/templates/aa214299-cea2-4dbb-9a79-30f07c6bc5f6.png"
                },
                new H1Block
                {
                    TemplateId = 2,
                    Order = 1,
                    H1Text = "H1 text",
                    PText =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend.",
                    ImageUrl = "http://localhost:8080/uploads/templates/b655a1db-18cb-47cb-8939-7e2e5f6116d4.png"
                });
        
        modelBuilder.Entity<TextBlock>()
            .HasData(
                new TextBlock
                {
                    TemplateId = 1,
                    Order = 2,
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend."
                },
                new TextBlock
                {
                    TemplateId = 2,
                    Order = 2,
                    Text =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In gravida porta sem, sit amet lobortis nunc rutrum in. Ut at ex ut ante blandit gravida a eu nisl. Fusce a lacus ullamcorper, ultrices neque eu, cursus risus. Cras nisl purus, dignissim in efficitur quis, aliquam id odio. Suspendisse eu risus accumsan, iaculis augue id, porta elit. Fusce faucibus, erat vitae faucibus sagittis, dui dolor tincidunt urna, ut vulputate leo lorem ac eros. Aenean fermentum posuere mattis. Suspendisse scelerisque felis diam, sed ultrices ante luctus sed. Fusce posuere nunc a felis eleifend, et sollicitudin mi eleifend."
                });
        
        modelBuilder.Entity<CatalogBlock>()
            .HasData(
                new CatalogBlock
                {
                    TemplateId = 1,
                    Order = 3,
                    Type = 0
                },
                new CatalogBlock
                {
                    TemplateId = 2,
                    Order = 3,
                    Type = 0
                });
        
        modelBuilder.Entity<FooterBlock>()
            .HasData(
                new FooterBlock
                {
                    TemplateId = 1,
                    Order = 4,
                    Type = 0
                },
                new FooterBlock
                {
                    TemplateId = 2,
                    Order = 4,
                    Type = 0
                });
        
        base.OnModelCreating(modelBuilder);
    }
}