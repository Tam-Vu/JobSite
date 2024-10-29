
namespace JobSite.Infrastructure.EntityFrameworkCore;
using JobSite.Infrastructure.Security.BindingEnvClasses;
using JobSite.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

public static class EntityFrameworkRegisteration
{
    public static WebApplicationBuilder AddEntityFramewordCore(this WebApplicationBuilder builder)
    {
        // builder.Configuration
        //     .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
        //     .AddEnvironmentVariables()
        //     .Build();

        // var dataConfig =
        // builder.Configuration.GetSection(nameof(DatabaseConfiguration)).Get<DatabaseConfiguration>();

        // if (dataConfig?.ConnectionString == null)
        // {
        //     throw new ArgumentNullException(nameof(dataConfig.ConnectionString));
        // }

        var dataConfig = new DatabaseConfiguration();
        builder.Configuration.GetSection(DatabaseConfiguration.dataConfig).Bind(dataConfig);

        builder.Services.AddDbContext<ApplicationDbContext>((provider, options) =>
        {
            //add interceptors here

            options.UseNpgsql(dataConfig.ConnectionString, opt =>
            {
                opt.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            });
        });
        return builder;
    }
}