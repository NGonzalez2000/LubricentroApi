using ErrorOr;
using Lubricentro.Application.ChatMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Domain.ChatMessageAggregate;
using Lubricentro.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.ChatMediator.Command.GetConversation;

public class GetConversationCommandHandler(IChatRepository chatRepository) : IRequestHandler<GetConversationCommand, ErrorOr<List<ChatMessageResult>>>
{
    private readonly IChatRepository _chatRepository = chatRepository;
    public async Task<ErrorOr<List<ChatMessageResult>>> Handle(GetConversationCommand request, CancellationToken cancellationToken)
    {
        UserId senderId = UserId.Create(request.SenderId);
        UserId receptorId = UserId.Create(request.ReceptorId);

        List<ChatMessage> messages = await _chatRepository.GetConversation(senderId, receptorId);

        List<ChatMessageResult> result = [];
        foreach (ChatMessage message in messages)
        {
            result.Add(new(message.SenderId.Value.ToString(), message.ReceptorId.Value.ToString(), message.MessageText));
        }
        return result;
    }
}
