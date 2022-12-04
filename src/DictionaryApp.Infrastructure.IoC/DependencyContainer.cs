using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DictionaryApp.Infrastructure.IoC;
using DictionaryApp.Application;

namespace DictionaryApp.Infrastructure.IoC;

public static class DependencyContainer
{
    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services.ConfigureApplication();

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration) =>
        services.ConfigureInfrastructure(configuration);
}