
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
        services.AddSingleton(jwtConfig!);
        var key = Encoding.ASCII.GetBytes(jwtConfig!.Secret);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                };
            });
        return builder;
    }

    public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;

        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "ChitChat API",
            });

            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer YOUR_TOKEN')",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference= new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id=JwtBearerDefaults.AuthenticationScheme
                            }
                        }, new string[]{}
                    }
            });
            option.CustomSchemaIds(type => type.ToString());

        });
        return builder;
    }
    public static IServiceCollection AddPresentationService(this IServiceCollection services)
    {
        AddAuthServices(services);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    private static void AddAuthServices(this IServiceCollection services)
    {
        //must add current user for infrastructure to use (it will be error if not added) 
        services.AddScoped<IUser, CurrentUser>();
        // services.AddHttpContextAccessor();
    }
}