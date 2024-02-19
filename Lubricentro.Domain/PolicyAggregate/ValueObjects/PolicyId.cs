using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.PolicyAggregate.ValueObjects;

public class PolicyId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private PolicyId(Guid value)
    {
        Value = value;
    }
    public static PolicyId Create(Guid value)
    {
        return new PolicyId(value);
    }

    public static PolicyId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
