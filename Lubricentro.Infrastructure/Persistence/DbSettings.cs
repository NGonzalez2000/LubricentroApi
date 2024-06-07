namespace Lubricentro.Infrastructure.Persistence;

internal class DbSettings
{
    public const string SectionName = "ConnectionStrings";
    public string Default {  get; set; } = string.Empty;
    public string Old {  get; set; } = string.Empty;
    public string Migration {  get; set; } = string.Empty;
}
