namespace Lubricentro.Infrastructure.Services.Emails;

internal class OutlookSettings
{
    public const string SectionName = "EmailSettings:Outlook";
    public string Smtp {  get; set; } = string.Empty;
    public int Port { get; set; }
}
