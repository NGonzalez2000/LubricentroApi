using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.PermissionAggregate.ValueObjects;

public class PermissionId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private PermissionId(Guid value)
    {
        Value = value;
    }
    public static PermissionId Create(Guid value)
    {
        return new PermissionId(value);
    }

    public static PermissionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
