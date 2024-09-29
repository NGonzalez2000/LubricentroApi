namespace Lubricentro.Application.PhoneMediator;

public record PhoneCommand(Guid Id, string NationalId, string Value, bool IsActive)
{
}
