using ErrorOr;
using Lubricentro.Application.ChatMediator.Common;
using MediatR;

namespace Lubricentro.Application.ChatMediator.Command.GetConversation;

public record GetConversationCommand(Guid SenderId, Guid ReceptorId) : IRequest<ErrorOr<List<ChatMessageResult>>>
{
}
