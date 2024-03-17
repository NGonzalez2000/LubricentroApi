using Lubricentro.Application.Common.Interfaces.Hubs;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Domain.ChatMessageAggregate;
using Lubricentro.Domain.UserAggregate.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Lubricentro.Infrastructure.Hubs;
[Authorize(Policy = "ChatPolicy")]
public class ChatHub(IChatRepository chatRepository) : Hub<IChatHub>
{
    private readonly IChatRepository _chatRepository = chatRepository;
    public async void SendMessageAsync(string receptorId, string message)
    {
        var senderId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        await Clients.User(receptorId).ReciveMessageAsync(senderId, message);
        UserId sender = UserId.Create(new(senderId));
        UserId receptor = UserId.Create(new(receptorId));
        ChatMessage chatMessage = ChatMessage.Create(sender, receptor, message);
        _chatRepository.SaveMessage(chatMessage);
        
    }
}
