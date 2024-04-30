using MasterCRM.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure;

public class CrmDbContext : IdentityDbContext<Master>
{
    public DbSet<Master> Masters { get; set; } = null!; // Identity model
    
    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<Client> Clients { get; set; } = null!;
    
    public DbSet<Stage> Stages { get; set; } = null!;

    public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}