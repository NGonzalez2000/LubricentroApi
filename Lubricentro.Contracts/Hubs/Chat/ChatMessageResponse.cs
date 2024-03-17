namespace Lubricentro.Contracts.Hubs.Chat;

public record ChatMessageResponse(string SenderId, string ReceptorId, string Message)
{
}
