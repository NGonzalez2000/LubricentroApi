using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.AddressAggregate.ValueObjects;

public class AddressId : AggregateRootId<Guid>
{
    public override Guid Value { get ; protected set ; }

    private AddressId(Guid value)
    {
        Value = value;
    } 

    public static AddressId Create(Guid value)
    { 
        return new (value);
    }

    public static AddressId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
