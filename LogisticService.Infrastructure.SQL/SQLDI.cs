using LogisticService.Domain.Interfaces.Repositories;
using LogisticService.Infrastructure.SQL.Repositories;
using LogisticService.SQL.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogisticService.Infrastructure.SQL;
public static class RepositoriesDI
{
    public static IServiceCollection AddSQLLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ITrucksRepository, TrucksRepository>();
        services.AddTransient<IServicesRepository, ServicesRepository>();
        services.Configure<RepositorySettings>(configuration.GetSection(nameof(RepositorySettings)));
        return services;
    }
}

