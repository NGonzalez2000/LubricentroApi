using Lubricentro.Domain.BrandAggregate.ValueObjects;
using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.ProviderAggregate;

namespace Lubricentro.Domain.BrandAggregate;

public class Brand : AggregateRoot<BrandId, Guid>
{
    public string Name { get; private set; }
    private Brand(BrandId id, string name) : base(id)
    {
        Name = name;
    }

    public void Update(string name)
    {
        Name = name;
    }

    public static Brand Create(string name)
    {
        return new(BrandId.CreateUnique(), name);
    }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private Brand() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
