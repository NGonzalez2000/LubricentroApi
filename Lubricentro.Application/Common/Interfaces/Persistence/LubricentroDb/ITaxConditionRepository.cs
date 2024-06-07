using Lubricentro.Domain.TaxConditionAggregate;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface ITaxConditionRepository : IRepository<TaxCondition, TaxConditionId>
{
    public TaxCondition? GetByDescription(string description);
    public TaxCondition? GetById(TaxConditionId Id);
    public Task<List<TaxCondition>> GetAllAsync();
}
