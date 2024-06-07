using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.UserAggregate;
using Lubricentro.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

public class UserRepository(LubricentroDbContext dbContext) : Repository<User, UserId>(dbContext), IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
    {
        return await DbContext.Users.Include(u => u.Role).ThenInclude(r => r.Policies).FirstOrDefaultAsync(u => u.UserName == email);
    }

    public async Task<User?> GetUserByIdAsync(UserId Id)
    {
        return await DbContext.Users.FirstOrDefaultAsync(u => u.Id == Id);
    }
}
