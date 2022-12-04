using DictionaryApp.Application.Abstractions;
using DictionaryApp.Application.Services;
using DictionaryApp.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace DictionaryApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IHashingService, BcryptHashingService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
