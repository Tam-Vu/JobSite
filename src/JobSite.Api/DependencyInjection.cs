
using JobSite.Api.Services;
using JobSite.Application.Common.Security.Identity;

namespace JobSite.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        AddAuthServices(services);
        services.AddControllers();
        // services.AddSwaggerGen(c =>
        // {
        //     c.SwaggerDoc("v1", new() { Title = "JobSite.Api", Version = "v1" });
        // });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    private static void AddAuthServices(this IServiceCollection services)
    {
        //must add current user for infrastructure to use (it will be error if not added) 
        services.AddScoped<IUser, CurrentUser>();
    }
}