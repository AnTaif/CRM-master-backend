using MasterCRM.Application.Interfaces;
using MasterCRM.Application.Services.User;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Interfaces;
using MasterCRM.Infrastructure;
using MasterCRM.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAuth(this IServiceCollection services)
    {
        services.AddIdentity<Master, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = true;
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedAccount = false;
        })
        .AddEntityFrameworkStores<CrmDbContext>()
        .AddDefaultTokenProviders();
    }

    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
    }
    
    public static void AddInfrastructureLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CrmDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        services.AddTransient<IRepository<Client, Guid>, ClientRepository>();
        services.AddTransient<IRepository<Order, Guid>, OrderRepository>();
        services.AddTransient<IRepository<Product, Guid>, ProductRepository>();
    }
}