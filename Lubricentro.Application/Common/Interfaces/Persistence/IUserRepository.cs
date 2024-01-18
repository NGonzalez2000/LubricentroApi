using Lubricentro.Domain.UserAggregate;
using Lubricentro.Domain.UserAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence;

public interface IUserRepository : IRepository<User,UserId>
{
    Task<User?> GetUserByEmail(string email);
}
