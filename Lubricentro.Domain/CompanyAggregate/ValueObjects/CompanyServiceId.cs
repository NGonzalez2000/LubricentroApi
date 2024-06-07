using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.CompanyAggregate.Entities;

namespace Lubricentro.Domain.CompanyAggregate.ValueObjects;

public class CompanyServiceId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private CompanyServiceId(Guid value)
    {
        Value = value;
    }

    public static CompanyServiceId Create(Guid value)
    {
        return new(value);
    }
    public static CompanyServiceId CreateUnique()
    { 
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
