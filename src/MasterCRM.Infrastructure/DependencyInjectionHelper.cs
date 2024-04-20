using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Interfaces;
using MasterCRM.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MasterCRM.Infrastructure;

public static class DependencyInjectionHelper
{
    public static void AddInfrastructureLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CrmDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IRepository<Client, Guid>, ClientRepository>();
        services.AddTransient<IRepository<Deal, Guid>, DealRepository>();
        services.AddTransient<IRepository<Product, Guid>, ProductRepository>();
    }
}