using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Lubricentro.Domain.ProductAggregate;

namespace Lubricentro.Domain.CompanyAggregate.Entities;

public class StockItem : AggregateRoot<StockItemId, Guid>
{
    public Product Product { get; private set; }
    public StockItemLocation Location { get; private set; }
    public int Cuantity { get; private set; }
    private StockItem(StockItemId id, Product product, StockItemLocation location, int cuantity) : base(id)
    {
        Product = product;
        Location = location;
        Cuantity = cuantity;
    }

    public static StockItem Create(Product product, StockItemLocation location)
    {
        return new(StockItemId.CreateUnique(), product, location, 0);
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    private StockItem() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
}
