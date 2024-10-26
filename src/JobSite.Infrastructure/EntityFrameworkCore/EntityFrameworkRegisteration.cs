
namespace JobSite.Infrastructure.EntityFrameworkCore;
using JobSite.Infrastructure.Security.BindingEnvClasses;
using JobSite.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        builder.Services.AddDbContext<ApplicationDbContext>((provider, options) =>
        {
            //add interceptors here

            options.UseNpgsql(@"Host=localhost;Username=postgres;Password=12345;Database=jobsite", opt =>
            {
                opt.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            });
        });
        return builder;
    }
}