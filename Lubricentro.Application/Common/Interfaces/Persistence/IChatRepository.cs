using Lubricentro.Domain.ChatMessageAggregate;
using Lubricentro.Domain.UserAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence
{
    public interface IChatRepository
    {
        void SaveMessage(ChatMessage message);
        Task<List<ChatMessage>> GetConversation(UserId senderId, UserId receptorId);
    }
}
