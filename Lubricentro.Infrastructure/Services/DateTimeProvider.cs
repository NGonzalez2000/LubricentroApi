using Lubricentro.Application.Common.Interfaces.Services;

namespace Lubricentro.Infrastructure.Services;

internal class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
