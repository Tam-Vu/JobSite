namespace JobSite.Infrastructure.Security.BindingEnvClasses;

public sealed class DatabaseConfiguration
{
    public const string dataConfig = "DatabaseConfiguration";
    public string ConnectionString { get; set; } = null!;
}