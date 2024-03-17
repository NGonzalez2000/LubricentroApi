namespace Lubricentro.Infrastructure.Persistence;

internal class DbSettings
{
    public const string SectionName = "ConnectionStrings";
    public string Default {  get; set; } = string.Empty;
}
