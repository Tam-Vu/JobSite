public sealed class EmailSenderSetting
{
    public const string EmailSettingConfig = "EmailSenderSettings";
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int Port { get; set; }
    public string Server { get; set; } = null!;
    public bool EnableSsl { get; set; }
}