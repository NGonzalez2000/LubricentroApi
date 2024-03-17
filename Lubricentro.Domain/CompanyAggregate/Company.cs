using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;

namespace Lubricentro.Domain.CompanyAggregate;

public class Company : AggregateRoot<CompanyId,Guid>
{
    public string Name { get; private set; }
    public string Cuil { get; private set; }
    private Company(CompanyId id, string name, string cuil)
        : base(id)
    {
        Name = name;
        Cuil = cuil;

    }

    public static Company Create(string name,string cuil)
    {
        return new(CompanyId.CreateUnique(), name, cuil);
    }

    public void ChangeCompanyName(string name)
    {
        Name = name;
    }
    public void ChangeCuil(string cuil)
    {
        Cuil = cuil;
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private Company() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
