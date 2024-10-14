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

    public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}