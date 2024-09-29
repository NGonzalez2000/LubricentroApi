using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.EmailAggregates.ValueObjects;

namespace Lubricentro.Domain.EmailAggregates;

public class Email : AggregateRoot<EmailId, Guid>
{
    public string Value { get; private set; }
    public bool IsActive { get; private set; }
    private Email(EmailId id, string value, bool isActive) : base(id) 
    {
        Value = value;
        IsActive = isActive;
    }
    public void Update(string value, bool isActive)
    {
        Value = value;
        IsActive = isActive;
    }
    public static Email Create(string value, bool isActive)
    {
        return new(EmailId.CreateUnique(), value, isActive);
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private Email() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
