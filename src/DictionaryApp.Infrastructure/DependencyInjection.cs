using DataAccessLibrary.Common;
using DataAccessLibrary.ConnectionFactories;
using DataAccessLibrary.DbDataAccess;
using DataAccessLibrary.Interfaces;
using DictionaryApp.Application.Common.Abstractions.Authentication;
using DictionaryApp.Domain.Abstractions;
using DictionaryApp.Domain.Common.Authentication;
using DictionaryApp.Infrastructure.Authentication;
using DictionaryApp.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace DictionaryApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();

        services.AddSingleton<ISqlOptions>(new SqlOptions { CommandType = CommandType.StoredProcedure });
        services.AddScoped<IConnectionFactory, SqlServerConnectionFactory>();
        services.AddScoped<ISqlDataAccess, SqlDataAccess>();
        services.AddScoped<IUserData, UserData>();

        return services;
    }
}
