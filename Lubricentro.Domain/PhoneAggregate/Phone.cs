using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.PhoneAggregate.ValueObjects;

namespace Lubricentro.Domain.PhoneAggregate;

public class Phone : AggregateRoot<PhoneId, Guid>
{
    public bool IsActive { get; private set; }
    public string NationalId { get; private set; }
    public string Value {  get; private set; }
    private Phone(PhoneId id, string nationalId, string value, bool isActive) : base(id)
    {
        NationalId = nationalId;
        Value = value;
        IsActive = isActive;
    }
    public static Phone Create(string nationalId, string value, bool isActive)
    {
        return new Phone(PhoneId.CreateUnique(), nationalId, value, isActive);
    }
    public void Update(string nationalId, string value, bool isActive)
    {
        NationalId = nationalId;
        Value = value;
        IsActive = isActive;
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private Phone()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    {
        
    }
}
