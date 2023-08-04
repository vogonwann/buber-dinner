using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schedule.Me.Application.Common.Interfaces.Authentication;
using Schedule.Me.Application.Common.Interfaces.Persistence;
using Schedule.Me.Application.Common.Interfaces.Services;
using Schedule.Me.Infrastructure.Authentication;
using Schedule.Me.Infrastructure.Persistence;
using Schedule.Me.Infrastructure.Services;

namespace Schedule.Me.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration
        )
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}

