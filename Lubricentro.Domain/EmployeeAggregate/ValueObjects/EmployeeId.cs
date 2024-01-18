using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.EmployeeAggregate.ValueObjects;

public sealed class EmployeeId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private EmployeeId(Guid value)
    {
        Value = value;
    }

    public static EmployeeId Create(Guid value)
    {
        return new EmployeeId(value);
    }

    public static EmployeeId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
