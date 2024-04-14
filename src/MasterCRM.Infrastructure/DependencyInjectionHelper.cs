using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MasterCRM.Infrastructure;

public static class DependencyInjectionHelper
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CrmDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }
}