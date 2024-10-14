namespace JobSite.Infrastructure.Security.BindingEnvClasses;

public sealed class JWTConfig
{
    public string? secretKey { get; set; }
    public string? issuer { get; set; }
    public string? audience { get; set; }
    public int expiry { get; set; }
}