using System.Reflection;
using JobSite.Application.Common.Behaviours;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobSite.Application;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddApplicationBuilder(this WebApplicationBuilder builder)
    {
        return builder;
    }

    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            // config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizedBehavior<,>));
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBahaviour<,>));
            // config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
        });
        return services;
    }
}