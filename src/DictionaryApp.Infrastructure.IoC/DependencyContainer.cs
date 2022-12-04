using Microsoft.Extensions.DependencyInjection;

namespace DictionaryApp.Infrastructure.IoC;

public static class DependencyContainer
{
    public static IServiceCollection AddApplication(this IServiceCollection services) => 
        services.AddApplication();

    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services.AddInfrastructure();
}
