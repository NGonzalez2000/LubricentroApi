using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.TaxConditionAggregate;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class TaxConditionRepository(LubricentroDbContext dbContext) : Repository<TaxCondition, TaxConditionId>(dbContext), ITaxConditionRepository
{
    public async Task<List<TaxCondition>> GetAllAsync()
    {
        return await DbContext.TaxConditions.ToListAsync();
    }

    public TaxCondition? GetByDescription(string description)
    {
        return DbContext.TaxConditions.FirstOrDefault(tc => tc.Description == description);
    }

    public TaxCondition? GetById(TaxConditionId Id)
    {
        return DbContext.TaxConditions.FirstOrDefault(tc => tc.Id == Id);
    }
}
