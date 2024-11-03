
namespace JobSite.Infrastructure.EntityFrameworkCore;
using JobSite.Infrastructure.Common.Security.BindingEnvClasses;
using JobSite.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JobSite.Infrastructure.EntityFrameworkCore.Interceptors;
using JobSite.Application.Common.Interfaces;

public static class EntityFrameworkRegisteration
{
    public static WebApplicationBuilder AddEntityFramewordCore(this WebApplicationBuilder builder)
    {
        var dataConfig = new DatabaseConfiguration();
        builder.Configuration.GetSection(DatabaseConfiguration.dataConfig).Bind(dataConfig);

        builder.Services.AddScoped<AuditableEntityInterceptor>();
        builder.Services.AddScoped<DispatchDomainEventsInterceptor>();

        builder.Services.AddDbContext<ApplicationDbContext>((provider, options) =>
        {
            //add interceptors here
            options
                .AddInterceptors(provider.GetRequiredService<AuditableEntityInterceptor>())
                .AddInterceptors(provider.GetRequiredService<DispatchDomainEventsInterceptor>());

            options.UseNpgsql(dataConfig.ConnectionString, opt =>
            {
                opt.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            });
        });
        builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        return builder;
    }
}