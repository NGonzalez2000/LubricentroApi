using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;

namespace Lubricentro.Domain.CompanyAggregate.Entities;

public class CompanyService : AggregateRoot<CompanyServiceId, Guid>
{
    public string Name { get; private set; }
    public Company? Company { get; private set; }
    private CompanyService(CompanyServiceId id, Company company, string name) : base(id)
    {
        Name = name;
        Company = company;
    }

    public static CompanyService Create(Company company, string name)
    {
        return new(CompanyServiceId.CreateUnique(), company, name);
    }

    public void SetCompany(Company? company)
    {
        Company = company;
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private CompanyService() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
