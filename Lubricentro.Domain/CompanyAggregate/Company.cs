using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;

namespace Lubricentro.Domain.CompanyAggregate;

public class Company : AggregateRoot<CompanyId,Guid>
{
    public string Name { get; private set; }
    public string Cuil { get; private set; }
    public string Email { get; private set; } 
    public string Password { get; private set; } 
    public List<CompanyService> Services { get; private set; }
    private Company(CompanyId id, string name, string cuil, string email, string password)
        : base(id)
    {
        Name = name;
        Cuil = cuil;
        Email = email;
        Password = password;
        Services = [];
    }

    public static Company Create(string name,string cuil, string email, string password)
    {
        return new(CompanyId.CreateUnique(), name, cuil, email, password);
    }

    public void ChangeCompanyName(string name)
    {
        Name = name;
    }
    public void ChangeCuil(string cuil)
    {
        Cuil = cuil;
    }
    public void ChangeEmail(string email)
    {
        Email = email;
    }
    public void ChangePassword(string password)
    {
        Password = password;
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private Company() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
