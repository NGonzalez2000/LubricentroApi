using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.PolicyAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IPolicyRepository : IRepository<Policy, PolicyId>
{
    Task<Policy?> GetPolicyById(PolicyId id);
    List<Policy> GetAll();
}
