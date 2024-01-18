using Lubricentro.Domain.UserAggregate;

namespace Lubricentro.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
