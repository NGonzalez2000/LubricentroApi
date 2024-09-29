using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;

namespace Lubricentro.Domain.CompanyAggregate.Entities;

public class Branch : AggregateRoot<BranchId, Guid>
{
    public string Name { get; private set; }
    public string PointOfSale { get; private set; }
    public Address Address { get; private set; }
    public Stock Stock { get; private set; }
    private Branch(BranchId id, string name, string pointOfSale, Address address, Stock stock) : base(id)
    {
        Name = name;
        PointOfSale = pointOfSale;
        Address = address;
        Stock = stock;
    }

    public void Update(string name, string pointOfSale, string country, string state, string city, string street, string postalCode)
    {
        Name = name;
        PointOfSale = pointOfSale;
        Address.Update(country, state, city, street, postalCode);
    }

    public static Branch Create(string name, string pointOfSale, Address address, Stock stock)
    {
        return new(BranchId.CreateUnique(), name, pointOfSale, address, stock);
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    private Branch() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
}
