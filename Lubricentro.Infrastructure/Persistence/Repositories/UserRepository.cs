using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Domain.UserAggregate;
using Lubricentro.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories;

public class UserRepository(LubricentroDbContext dbContext) : Repository<User,UserId>(dbContext), IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
    {
        return await DbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
    }
}
