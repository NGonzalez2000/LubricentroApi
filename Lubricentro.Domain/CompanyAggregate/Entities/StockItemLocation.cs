using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;

namespace Lubricentro.Domain.CompanyAggregate.Entities;

public class StockItemLocation : AggregateRoot<StockItemLocationId, Guid>
{
    public string X { get; private set; }
    public string Y { get; private set; }
    public string Z { get; private set; }

    private StockItemLocation(StockItemLocationId id, string x, string y, string z)
        : base(id)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static StockItemLocation Create(string x, string y, string z)
    {
        return new(StockItemLocationId.CreateUnique(), x, y, z);
    }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    private StockItemLocation() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
}
