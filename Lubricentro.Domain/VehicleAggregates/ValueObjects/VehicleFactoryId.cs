using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.VehicleAggregates.ValueObjects;

public class VehicleFactoryId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private VehicleFactoryId(Guid value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static VehicleFactoryId Create(Guid value)
    {
        return new(value);
    }
    public static VehicleFactoryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
