
namespace JobSite.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        // services.AddSwaggerGen(c =>
        // {
        //     c.SwaggerDoc("v1", new() { Title = "JobSite.Api", Version = "v1" });
        // });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}