using Lubricentro.Domain.PhoneAggregate;

namespace Lubricentro.Application.PhoneMediator;

public record PhoneResult(string Id, string NationalId, string Value, bool IsActive)
{
    public PhoneResult(Phone phone) : this(phone.Id.Value.ToString(), phone.NationalId, phone.Value, phone.IsActive)
    {
    }
}
