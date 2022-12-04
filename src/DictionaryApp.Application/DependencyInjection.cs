using DictionaryApp.Application.Abstractions;
using DictionaryApp.Application.Services.Common.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace DictionaryApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
