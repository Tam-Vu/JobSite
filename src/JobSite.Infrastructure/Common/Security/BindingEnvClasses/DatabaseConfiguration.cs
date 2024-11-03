namespace JobSite.Infrastructure.Common.Security.BindingEnvClasses;

public sealed class DatabaseConfiguration
{
    public const string dataConfig = "DatabaseConfiguration";
    public string ConnectionString { get; set; } = null!;
}