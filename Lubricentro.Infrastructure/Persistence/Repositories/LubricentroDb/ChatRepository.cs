using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.ChatMessageAggregate;
using Lubricentro.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class ChatRepository(LubricentroDbContext dbContext) : IChatRepository
{
    private readonly LubricentroDbContext _dbContext = dbContext;
    public void SaveMessage(ChatMessage message)
    {
        _dbContext.Add(message);
        _dbContext.SaveChanges();
    }
    public async Task<List<ChatMessage>> GetConversation(UserId senderId, UserId receptorId)
    {
        return await _dbContext.ChatMessages.Where(cm =>
        cm.SenderId == senderId && cm.ReceptorId == receptorId ||
        cm.SenderId == receptorId && cm.ReceptorId == senderId).OrderBy(c => c.DateTime).ToListAsync();
    }
}
