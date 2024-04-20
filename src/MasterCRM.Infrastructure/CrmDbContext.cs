using MasterCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Infrastructure;

public class CrmDbContext : DbContext
{
    public DbSet<Master> Masters { get; set; } = null!; // Identity model
    
    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<Customer> Customers { get; set; } = null!;

    public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }
}