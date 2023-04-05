using LogisticService.Domain.Interfaces.UseCases.Services;
using LogisticService.Domain.Interfaces.UseCases.Trucks;
using LogisticService.Domain.UseCases.Services;
using LogisticService.Domain.UseCases.Trucks;
using Microsoft.Extensions.DependencyInjection;

namespace LogisticService.Domain;
public static class DomainDI
{
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        services.AddTransient<ICreateTruckUseCase, CreateTruckUseCase>();
        services.AddTransient<IDeleteTruckUseCase, DeleteTruckUseCase>();
        services.AddTransient<IUpdateTruckUseCase, UpdateTruckUseCase>();
        services.AddTransient<IGetTrucksUseCase, GetTrucksUseCase>();
        services.AddTransient<IGetTruckByIdUseCase, GetTruckByIdUseCase>();
        services.AddTransient<ICreateServiceUseCase, CreateServiceUseCase>();
        services.AddTransient<IGetAllServicesUseCase, GetAllServicesUseCase>();
        return services;
    }
}

