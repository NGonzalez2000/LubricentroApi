namespace Lubricentro.Application.ChatMediator.Common;

public record ChatMessageResult(string SenderId, string ReceptorId, string Message)
{
}
