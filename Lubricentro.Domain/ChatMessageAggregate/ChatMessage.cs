using Lubricentro.Domain.ChatMessageAggregate.ValueObjects;
using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.UserAggregate.ValueObjects;

namespace Lubricentro.Domain.ChatMessageAggregate;

public class ChatMessage : AggregateRoot<ChatMessageId, Guid>
{
    public UserId SenderId { get; private set; }
    public UserId ReceptorId { get; private set; }
    public string MessageText { get; private set; }
    public DateTime DateTime { get; private set; }
    private ChatMessage(ChatMessageId id, UserId senderId, UserId receptorId, string messageText)
        : base(id)
    {
        SenderId = senderId;
        ReceptorId = receptorId;
        MessageText = messageText;
        DateTime = DateTime.Now;
    }

    public static ChatMessage Create(UserId senderId, UserId receptorId, string messageText)
    {
        return new(ChatMessageId.CreateUnique(), senderId, receptorId, messageText);
    }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private ChatMessage() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
