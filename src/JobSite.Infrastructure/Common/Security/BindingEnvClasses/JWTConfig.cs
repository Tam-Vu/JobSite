namespace JobSite.Infrastructure.Common.Security.BindingEnvClasses;

public sealed class JWTConfig
{
    public const string jwtConfig = "JwtSettings";
    public string Secret { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int TokenExpirationInMinutes { get; set; }
    public int RefreshTokenExpirationInDays { get; set; }
}