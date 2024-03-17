using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.CompanyAggregate.ValueObjects;

public class CompanyId : AggregateRootId<Guid>
{
    public override Guid Value { get ; protected set ; }
    private CompanyId(Guid value)
    {
        Value = value;
    }

    public static CompanyId CreateUnique()
    {
        return new CompanyId(Guid.NewGuid());
    }

    public static CompanyId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
