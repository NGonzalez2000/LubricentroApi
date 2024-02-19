using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.RoleAggregate.ValueObjects;

public class RoleId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private RoleId(Guid value)
    {
        Value = value;
    }

    public static RoleId CreateUnique()
    {
        return new RoleId(Guid.NewGuid());
    }

    public static RoleId Create(Guid roleId)
    {
        return new RoleId(roleId);
    }
}
