using Lubricentro.Application.Common.Interfaces.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Lubricentro.Infrastructure.Hubs;

public class ChatHub : Hub<IChatHub>
{
    public void SendMessage(string user, string message)
    {
        Clients.All.SendMessageAsync($"User: {user}, message: {message}");
    }
}
