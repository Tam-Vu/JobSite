using System.Net.Mail;
using JobSite.Api.Services;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.Common.Security.Jwt;
using JobSite.Infrastructure.Accounts.Persistence;
using JobSite.Infrastructure.Application.Persistence;
using JobSite.Infrastructure.Common.Middleware;
using JobSite.Infrastructure.Common.Persistence;
using JobSite.Infrastructure.Common.Security.BindingEnvClasses;
using JobSite.Infrastructure.Common.Security.Identity;
using JobSite.Infrastructure.Common.Security.Jwt;
using JobSite.Infrastructure.Employees.Persistence;
using JobSite.Infrastructure.Employers.Persistence;
using JobSite.Infrastructure.EntityFrameworkCore;
using JobSite.Infrastructure.InterviewSchedules.Persistence;
using JobSite.Infrastructure.Jobs.Persistence;
using JobSite.Infrastructure.Resumes.ExperienceDetails;
using JobSite.Infrastructure.Resumes.Persistence;
using JobSite.Infrastructure.Resumes.Skills;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        // .AddAppAuthorization()
        // builder.Services.AddInfrastructureService();
        return builder;
    }

    private static void AddEmailConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var emailConfig = new EmailSenderSetting();
        configuration.GetSection(EmailSenderSetting.EmailSettingConfig).Bind(emailConfig);
        services
            .AddFluentEmail(emailConfig.Username)
            .AddSmtpSender(new SmtpClient(emailConfig.Server)
            {
                Port = emailConfig.Port,
                Credentials = new System.Net.NetworkCredential(emailConfig.Username, emailConfig.Password),
                EnableSsl = emailConfig.EnableSsl
            });
    }

    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity();
        AddEmailConfig(services, configuration);
        services.AddSingleton(TimeProvider.System);
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IEmailSenderRepository, EmailSenderRepository>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IIdentityService, IdentitySerivce>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEmployerRepository, EmployerRepository>();
        services.AddScoped<IResumeRepository, ResumeRepository>();
        services.AddScoped<IExperienceDetailsRepository, ExperienceDetailsRepository>();
        services.AddScoped<IJobApplicationRepository, ApplicationRepository>();
        services.AddScoped<IInterviewScheduleRepository, InterviewScheduleRepository>();
        services.AddScoped<IUser, CurrentUser>();
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
        services.AddIdentity<Account, Role>(option =>
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
        services.AddTransient<DbInitializer>();
        return services;
    }
}