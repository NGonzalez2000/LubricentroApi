namespace Lubricentro.Infrastructure.Services.Emails;

internal class GmailSettings
{
    public const string SectionName = "GmailSettings";
    public string Smtp { get; set; } = string.Empty;
    public int Port { get; set; }
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}
