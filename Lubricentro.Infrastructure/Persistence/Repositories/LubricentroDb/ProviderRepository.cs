using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.ProviderAggregate;
using Lubricentro.Domain.ProviderAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class ProviderRepository(LubricentroDbContext dbContext) : Repository<Provider, ProviderId>(dbContext), IProviderRepository
{
    public Task<List<Provider>> GetAllAsync()
    {
        return DbContext.Providers.Include(p => p.Address).Include(p => p.TaxCondition).Include(p => p.Emails).Include(p => p.Phones).ToListAsync();
    }

    public Provider? GetById(ProviderId id)
    {
        return DbContext.Providers.Include(p => p.Address).Include(p => p.TaxCondition).Include(p => p.Emails).Include(p => p.Phones).FirstOrDefault(p => p.Id == id);
    }
}
