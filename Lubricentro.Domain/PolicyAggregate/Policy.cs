using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.PolicyAggregate.ValueObjects;
using Lubricentro.Domain.RoleAggregate;

namespace Lubricentro.Domain.PolicyAggregate;

public class Policy : AggregateRoot<PolicyId,Guid>
{
    public List<Role> Roles { get; set; } = [];
    private Policy(PolicyId policyId, string name) : base(policyId)
    {
        Name = name;
    }

    public string Name { get; private set; } = null!;
    public static Policy Create(string name)
    {
        return new Policy(PolicyId.CreateUnique(), name);
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private Policy() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
