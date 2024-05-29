using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        Assembly currentAssembly = Assembly.LoadFrom(typeof(DependencyInjection).Assembly.Location);
        services.AddMediatR(config => config.RegisterServicesFromAssembly(currentAssembly));
        services.AddValidatorsFromAssembly(currentAssembly);

        return services;
    }
}
