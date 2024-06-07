using Lubricentro.Application.Common.Interfaces.Persistence.OldDb;
using Lubricentro.Domain.OldAggregates;

namespace Lubricentro.Infrastructure.Persistence.Repositories.OldDb;

internal class OldTaxConditionRepository(OldDbContext dbContext) : OldRepository<OldTaxCondition>(dbContext), IOldTaxConditionRepository
{
}
