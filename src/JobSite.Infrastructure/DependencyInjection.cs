using JobSite.Domain.Identity;
using JobSite.Infrastructure.Accounts.Persistence;
using JobSite.Infrastructure.Common.Middleware;
using JobSite.Infrastructure.Common.Persistence;
using JobSite.Infrastructure.EntityFrameworkCore;
using JobSite.Infrastructure.Jobs.Persistence;
using JobSite.Infrastructure.Resumes.Skills;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
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
        services.AddIdentity();
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddProblemDetails();
        return services;
    }

    public static IApplicationBuilder AddInfrastructureApplication(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalHandlerExceptionMiddleware>();
        return app;
    }

    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<Account, UserRole>(option =>
        {
            option.SignIn.RequireConfirmedEmail = true;
        })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(30);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.User.RequireUniqueEmail = true;
        });
        return services;
    }
}