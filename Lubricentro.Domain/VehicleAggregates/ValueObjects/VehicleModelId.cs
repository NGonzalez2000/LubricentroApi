using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.VehicleAggregates.ValueObjects;

public class VehicleModelId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private VehicleModelId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static VehicleModelId Create(Guid value)
    {
        return new(value);
    }
    public static VehicleModelId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
