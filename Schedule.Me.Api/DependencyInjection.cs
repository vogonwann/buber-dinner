using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Schedule.Me.Api.Common.Errors;
using Schedule.Me.Api.Common.Mapping;

namespace Schedule.Me.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemsDetailFactory>();
        services.AddSingleton<ApiBehaviorOptions>();
        services.AddMappings();
        
        return services;
    }
}