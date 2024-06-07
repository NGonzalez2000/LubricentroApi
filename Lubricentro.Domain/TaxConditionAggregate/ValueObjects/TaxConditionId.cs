using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.TaxConditionAggregate.ValueObjects;

public class TaxConditionId : AggregateRootId<Guid>
{
    public override Guid Value { get ; protected set ; }

    private TaxConditionId(Guid value)
    {
        Value = value;
    }

    public static TaxConditionId Create(Guid value)
    {
        return new(value);
    }

    public static TaxConditionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
