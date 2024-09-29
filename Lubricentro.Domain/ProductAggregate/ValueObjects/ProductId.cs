using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;

namespace Lubricentro.Domain.ProductAggregate.ValueObjects;

public class ProductId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private ProductId(Guid value)
    {
        Value = value;
    }

    public static ProductId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ProductId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
