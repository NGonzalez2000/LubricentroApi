using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.VehicleAggregates.ValueObjects;

public class VehicleId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private VehicleId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static VehicleId Create(Guid value)
    {
        return new(value);
    }
    public static VehicleId CreateUnique() 
    {
        return new(Guid.NewGuid());
    }
}
