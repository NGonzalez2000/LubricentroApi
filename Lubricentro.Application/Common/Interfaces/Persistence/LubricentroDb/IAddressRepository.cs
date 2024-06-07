using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.AddressAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IAddressRepository : IRepository<Address, AddressId>
{
}
