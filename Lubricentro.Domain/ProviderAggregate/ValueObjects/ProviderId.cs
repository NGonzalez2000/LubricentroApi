using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.ProviderAggregate.ValueObjects;

public class ProviderId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private ProviderId(Guid value)
    {
        Value = value;
    }
    public static ProviderId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static ProviderId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
