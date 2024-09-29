using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.PhoneAggregate.ValueObjects;

public class PhoneId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private PhoneId(Guid value)
    {
        Value = value;
    }

    public static PhoneId Create(Guid value)
    {
        return new PhoneId(value);
    }
    public static PhoneId CreateUnique()
    {
        return new PhoneId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
