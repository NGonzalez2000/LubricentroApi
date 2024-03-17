namespace Lubricentro.Contracts.Hubs.Chat;

public record GetConversationRequest(Guid SenderId, Guid ReceptorId)
{
}
