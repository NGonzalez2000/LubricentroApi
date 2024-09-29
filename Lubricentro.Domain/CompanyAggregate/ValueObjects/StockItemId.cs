using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.CompanyAggregate.ValueObjects;

public class StockItemId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private StockItemId(Guid value)
    {
        Value = value;
    }

    public static StockItemId CreateUnique()
    {
        return new StockItemId(Guid.NewGuid());
    }

    public static StockItemId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
