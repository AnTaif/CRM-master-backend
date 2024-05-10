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
        
        base.OnModelCreating(modelBuilder);
    }
}