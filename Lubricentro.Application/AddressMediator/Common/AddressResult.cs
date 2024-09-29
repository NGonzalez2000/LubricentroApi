using Lubricentro.Domain.AddressAggregate;

namespace Lubricentro.Application.AddressMediator.Common;

public record AddressResult(string Country, string State, string City, string Street, string PostalCode)
{
    public AddressResult(Address address) : this(address.Country, address.State, address.City, address.Street, address.PostalCode) 
    {
    }
}
