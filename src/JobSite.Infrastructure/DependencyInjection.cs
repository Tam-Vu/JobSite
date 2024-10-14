using JobSite.Infrastructure.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobSite.Infrastructure;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddInfrastructureBuilder(this WebApplicationBuilder builder)
    {
        builder
            .AddEntityFramewordCore();
        //add caching here
        return builder;
    }

    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }

}