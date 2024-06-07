using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.AddressAggregate.ValueObjects;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class AddressRepository(LubricentroDbContext dbContext) : Repository<Address, AddressId>(dbContext), IAddressRepository
{
}
