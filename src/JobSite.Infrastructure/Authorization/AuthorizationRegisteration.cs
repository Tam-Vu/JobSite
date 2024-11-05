using System.Text;
using JobSite.Infrastructure.Common.Security.BindingEnvClasses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace JobSite.Infrastructure.Authorization;

internal static class AuthorizationRegisteration
{
    public static WebApplicationBuilder AddAppAuthorization(this WebApplicationBuilder builder)
    {
        var jWTConfig = new JWTConfig();
        builder.Configuration.GetSection(JWTConfig.jwtConfig).Bind(jWTConfig);
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jWTConfig.Issuer,
                    ValidAudience = jWTConfig.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jWTConfig.Secret))
                };
            });
        return builder;
    }
}