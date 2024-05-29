using MasterCRM.Application.Services.Auth.DefaultAuth;
using MasterCRM.Application.Services.Auth.ExternalAuth;
using MasterCRM.Application.Services.Clients;
using MasterCRM.Application.Services.Orders;
using MasterCRM.Application.Services.Orders.History;
using MasterCRM.Application.Services.Orders.Products;
using MasterCRM.Application.Services.Orders.Stages;
using MasterCRM.Application.Services.Products;
using MasterCRM.Application.Services.Products.Photos;
using MasterCRM.Application.Services.User;
using MasterCRM.Application.Services.Websites;
using MasterCRM.Application.Services.Websites.Constructor;
using MasterCRM.Application.Services.Websites.PublicWebsite;
using MasterCRM.Application.Services.Websites.Templates;
using MasterCRM.Domain.Common;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Interfaces;
using MasterCRM.Infrastructure.Data;
using MasterCRM.Infrastructure.Repositories.Clients;
using MasterCRM.Infrastructure.Repositories.Orders;
using MasterCRM.Infrastructure.Repositories.Products;
using MasterCRM.Infrastructure.Repositories.Websites;
using MasterCRM.Infrastructure.Services.Emails;
using MasterCRM.Infrastructure.Services.ExternalServices;
using MasterCRM.Infrastructure.Services.FileStorages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IEmailSender = MasterCRM.Domain.Interfaces.IEmailSender;

namespace MasterCRM.Api.Extensions;

public static class ServiceCollectionExtensions
{
    private static string uploadsUrl => GetUploadsUrl();

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
        services.AddTransient<IVkAuthService, VkAuthService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IProductPhotoService, ProductPhotoService>();
        services.AddTransient<IClientService, ClientService>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IStageService, StageService>();
        services.AddTransient<IOrderHistoryService, OrderHistoryService>();
        services.AddTransient<IOrderProductService, OrderProductService>();
        services.AddTransient<IWebsiteService, WebsiteService>();
        services.AddTransient<IConstructorService, ConstructorService>();
        services.AddTransient<ITemplateService, TemplateService>();

        return services;
    }
    
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services, ConfigurationManager configuration, string uploadsPath)
    {
        services.Configure<UploadsSettings>(options =>
        {
            options.WebsitesUrl = GetWebsitesUrl();
            options.UploadsPath = uploadsPath;
            options.UploadsUrl = uploadsUrl;
        });
        
        var connectionString = GetConnectionString();
        services.AddDbContext<CrmDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IProductPhotoRepository, ProductPhotoRepository>();
        services.AddTransient<IClientRepository, ClientRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IStageRepository, StageRepository>();
        services.AddTransient<IOrderHistoryRepository, OrderHistoryRepository>();
        services.AddTransient<IOrderProductRepository, OrderProductRepository>();
        services.AddTransient<IWebsiteRepository, WebsiteRepository>();
        services.AddTransient<ITemplateRepository, TemplateRepository>();
        services.AddTransient<IConstructorBlockRepository, ConstructorBlockRepository>();
        services.AddTransient<IGlobalStylesRepository, GlobalStylesRepository>();
        
        services.AddTransient<IFileStorage, RootFileStorage>();

        var vkServiceToken = Environment.GetEnvironmentVariable("VK_SERVICE_TOKEN") ?? "";
        var vkApiVersion = Environment.GetEnvironmentVariable("VK_API_VERSION") ?? "";
        
        services.AddTransient<IVkontakteService, VkontakteService>(_ => 
            new VkontakteService(vkApiVersion, vkServiceToken));

        var smtpSettings = configuration.GetSection("SmtpSettings").Get<SmtpSettings>() ??
                           new SmtpSettings("smtp.ethereal.email", 587, "noreply@masterskaya.online");
        var smtpUser = Environment.GetEnvironmentVariable("SMTP_USER") ?? "";
        var smtpPassword = Environment.GetEnvironmentVariable("SMTP_PASSWORD") ?? "";
        services.AddTransient<IEmailSender, EmailSender>(_ => 
            new EmailSender(smtpSettings, smtpUser, smtpPassword));
        services.AddTransient<IEmailTemplateService, EmailTemplateService>();

        return services;
    }

    /// <summary>
    /// Get connection string for the database, host changes depending on the running environment (docker or locally)
    /// </summary>
    /// <returns>
    /// Connection string in form of "Host={host};Port={port};Database={database};Username={user};Password={password}"
    /// </returns>
    private static string GetConnectionString()
    {
        // Changing database host depending on the running environment (Docker or Locally)
        var dbHost = Environment.GetEnvironmentVariable("DB_CONTAINER") ?? "localhost";
        const int dbPort = 5432;
        var dbName = Environment.GetEnvironmentVariable("DATABASE_NAME")!;
        var dbUser = Environment.GetEnvironmentVariable("DATABASE_USER")!;
        var dbPassword = Environment.GetEnvironmentVariable("DATABASE_PASSWORD")!;
            
        return $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";
    }
    
    private static string GetWebsitesUrl() =>
        Environment.GetEnvironmentVariable("WEBSITES_URL") ?? "http://localhost:8080/website/";

    private static string GetUploadsUrl() => 
        Environment.GetEnvironmentVariable("UPLOADS_URL") ?? "http://localhost:8080/uploads/";
}