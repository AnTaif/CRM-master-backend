using MasterCRM.Application.Services.Auth;
using MasterCRM.Application.Services.User;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Interfaces;
using MasterCRM.Infrastructure;
using MasterCRM.Infrastructure.ExternalServices;
using MasterCRM.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomAuth(this IServiceCollection services)
    {
        services.AddAuthentication().AddBearerToken();
        services.AddAuthorization();
        
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

        return services;
    }

    public static IServiceCollection AddCustomCors(this IServiceCollection services, string[]? origins)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("FrontendPolicy", policy =>
            {
                if (origins != null)
                    policy.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                else
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });
        });

        return services;
    }

    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IAuthService, AuthService>();

        return services;
    }
    
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        // Changing database host depending on the running environment (Docker or Locally)
        var dbHost = Environment.GetEnvironmentVariable("DB_CONTAINER") ?? "localhost";
        const int dbPort = 5432;
        var dbName = Environment.GetEnvironmentVariable("DATABASE_NAME")!;
        var dbUser = Environment.GetEnvironmentVariable("DATABASE_USER")!;
        var dbPassword = Environment.GetEnvironmentVariable("DATABASE_PASSWORD")!;
            
        var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";
        
        services.AddDbContext<CrmDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        services.AddTransient<IRepository<Client, Guid>, ClientRepository>();
        services.AddTransient<IRepository<Order, Guid>, OrderRepository>();
        services.AddTransient<IRepository<Product, Guid>, ProductRepository>();

        var vkServiceToken = Environment.GetEnvironmentVariable("VK_SERVICE_TOKEN") ?? "";
        var vkApiVersion = Environment.GetEnvironmentVariable("VK_API_VERSION") ?? "";
        
        services.AddTransient<IVkontakteService, VkontakteService>(_ => 
            new VkontakteService(vkApiVersion, vkServiceToken));

        return services;
    }
}