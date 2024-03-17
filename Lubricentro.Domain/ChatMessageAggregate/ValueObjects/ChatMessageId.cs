using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.ChatMessageAggregate.ValueObjects;

public class ChatMessageId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set ; }
    private ChatMessageId(Guid value)
    {
        Value = value;
    }

    public static ChatMessageId Create(Guid value)
    {
        return new(value);
    }
    public static ChatMessageId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
