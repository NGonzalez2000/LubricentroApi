using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.CompanyAggregate.ValueObjects;

public class StockId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private StockId(Guid value)
    {
        Value = value;
    }

    public static StockId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static StockId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
