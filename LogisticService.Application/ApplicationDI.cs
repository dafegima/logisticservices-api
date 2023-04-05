using System.Reflection;
using FluentValidation;
using LogisticService.Application.Commands.Trucks.Create;
using LogisticService.Application.MapperProfiles;
using LogisticService.Application.PipelineBehaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LogisticService.Application;
public static class ApplicationDI
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateTruckCommand).Assembly);
        services.AddValidatorsFromAssemblies(new List<Assembly>() { typeof(CreateTruckCommandValidator).Assembly });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddAutoMapper(typeof(TruckMapperProfiles).Assembly);
        return services;
    }
}

