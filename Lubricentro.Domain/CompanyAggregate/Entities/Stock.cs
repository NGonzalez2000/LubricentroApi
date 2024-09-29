using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Lubricentro.Domain.ProductAggregate;

namespace Lubricentro.Domain.CompanyAggregate.Entities;

public class Stock : AggregateRoot<StockId, Guid>
{
    public List<StockItem> Items { get; private set; }
    private Stock(StockId id)
        : base(id)
    {
        Items = [];
    }

    public void AddItem(StockItem item)
    {
        if (Items.Any(si => si.Product == item.Product))
            return;

        Items.Add(item);
    }

    public static Stock Create()
    {
        return new(StockId.CreateUnique());
    }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    private Stock()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    {

    }
}
