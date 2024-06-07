using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.ClientAggregate.ValueObjects;

public class ClientId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private ClientId(Guid value)
    {
        Value = value;
    }

    public static ClientId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ClientId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
