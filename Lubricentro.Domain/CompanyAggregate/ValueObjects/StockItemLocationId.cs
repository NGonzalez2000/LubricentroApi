using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.CompanyAggregate.ValueObjects;

public class StockItemLocationId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private StockItemLocationId(Guid value)
    {
        Value = value;
    }

    public static StockItemLocationId CreateUnique()
    {
        return new StockItemLocationId(Guid.NewGuid());
    }

    public static StockItemLocationId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}