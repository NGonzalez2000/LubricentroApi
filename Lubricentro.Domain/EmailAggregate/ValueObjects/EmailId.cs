using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.EmailAggregate.ValueObjects;

public class EmailId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set ; }

    private EmailId(Guid value)
    {
       Value = value;
    }

    public static EmailId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static EmailId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
