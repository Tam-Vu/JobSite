using JobSite.Infrastructure.Common.Middleware;
using JobSite.Infrastructure.EntityFrameworkCore;
using JobSite.Infrastructure.Jobs.Persistence;
using JobSite.Infrastructure.Resumes.Skills;
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
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddProblemDetails();
        return services;
    }

    public static IApplicationBuilder AddInfrastructureApplication(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalHandlerExceptionMiddleware>();
        return app;
    }
}