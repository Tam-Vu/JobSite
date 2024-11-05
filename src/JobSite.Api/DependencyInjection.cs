
using System.Text;
using JobSite.Api.Services;
using JobSite.Application.Common.Security.Identity;
using JobSite.Infrastructure.Common.Security.BindingEnvClasses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace JobSite.Api;
public static class DependencyInjection
{
    public static WebApplicationBuilder AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddPresentationService();
        builder.AddJwt();
        builder.AddSwagger();
        return builder;
    }

    private static WebApplicationBuilder AddJwt(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;

        var jwtConfig = new JWTConfig();
        jwtConfig = configuration.GetSection(JWTConfig.jwtConfig).Get<JWTConfig>();
        services.AddSingleton(jwtConfig);
        var key = Encoding.ASCII.GetBytes(jwtConfig.Secret);

        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    ValidateLifetime = true,
                };
            });
        return builder;
    }

    private static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "JobSite",
                Version = "v1",

            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
            options.CustomSchemaIds(type => type.ToString());
        });
        return builder;
    }
    public static IServiceCollection AddPresentationService(this IServiceCollection services)
    {
        AddAuthServices(services);
        services.AddControllers();
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