using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Lubricentro.Domain.UserAggregate;

namespace Lubricentro.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken(User user, BranchId branchId);
    }
}
