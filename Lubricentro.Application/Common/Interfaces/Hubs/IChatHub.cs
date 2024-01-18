namespace Lubricentro.Application.Common.Interfaces.Hubs
{
    public interface IChatHub
    {
        Task SendMessageAsync(string message);
        Task OnConnectedAsync();
    }
}
