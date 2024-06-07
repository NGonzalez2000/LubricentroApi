using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.UserAggregate;

namespace Lubricentro.Application.Common.Interfaces.Services;

public interface IUserProvider
{
    Task<User> CreateUserAsync(string username, Role role);
    Task<User?> RecoverPasswordAsync(string username);
}
