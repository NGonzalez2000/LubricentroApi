using Lubricentro.Domain.ProviderAggregate;
using Lubricentro.Domain.ProviderAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IProviderRepository : IRepository<Provider, ProviderId>
{
    Provider? GetById(ProviderId id);
    Task<List<Provider>> GetAllAsync();
}
