namespace Lubricentro.Application.Common.Interfaces.Hubs
{
    public interface IChatHub
    {
        Task ReciveMessageAsync(string senderId, string message);
    }
}
