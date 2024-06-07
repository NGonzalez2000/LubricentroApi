using Lubricentro.Domain.AddressAggregate.ValueObjects;
using Lubricentro.Domain.Common.Models;

namespace Lubricentro.Domain.AddressAggregate;

public class Address : AggregateRoot<AddressId, Guid>
{
    public string Country { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string PostalCode { get; private set; }

    private Address(AddressId id, string country, string state, string city, string street, string postalcode)
        : base(id)
    {
        Country = country;
        State = state;
        City = city;
        Street = street;
        PostalCode = postalcode;
    }

    public static Address Create(string country, string state, string city, string street, string postalcode)
    {
        return new(AddressId.CreateUnique(), country, state, city, street, postalcode);
    }

    public void Update(string country, string state, string city, string street, string postalcode)
    {
        Country = country;
        State = state;
        City = city;
        Street = street;
        PostalCode = postalcode;
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private Address() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
