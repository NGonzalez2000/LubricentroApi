using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.PolicyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories;

public class PolicyRepository(LubricentroDbContext dbContext) : Repository<Policy, PolicyId>(dbContext), IPolicyRepository
{
    public List<Policy> GetAll()
    {
        return [.. DbContext.Policies];
    }

    public async Task<Policy?> GetPolicyById(PolicyId id)
    {
        return await DbContext.Policies.FirstOrDefaultAsync(x => x.Id == id);
    }
}
