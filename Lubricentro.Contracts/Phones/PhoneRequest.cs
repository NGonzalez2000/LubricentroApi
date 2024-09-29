namespace Lubricentro.Contracts.Phones;

public record PhoneRequest(Guid Id, string NationalId, string Value, bool IsActive)
{
}
