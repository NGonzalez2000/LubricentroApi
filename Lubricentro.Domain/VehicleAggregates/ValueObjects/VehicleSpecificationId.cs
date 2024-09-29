using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.VehicleAggregates.ValueObjects;

public class VehicleSpecificationId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private VehicleSpecificationId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static VehicleSpecificationId Create(Guid value)
    {
        return new(value);
    }
    public static VehicleSpecificationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
