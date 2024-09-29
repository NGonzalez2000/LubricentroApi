using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.CompanyAggregate.ValueObjects;

public class BranchId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private BranchId(Guid value)
    {
        Value = value;
    }

    public static BranchId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static BranchId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
