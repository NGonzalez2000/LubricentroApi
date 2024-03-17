using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.PolicyAggregate.ValueObjects;
using Lubricentro.Domain.RoleAggregate.ValueObjects;

namespace Lubricentro.Domain.RoleAggregate;

public class Role : AggregateRoot<RoleId, Guid>
{
    public string Name;
    private readonly List<Policy> _policies = [];
    public IReadOnlyList<Policy> Policies => _policies.ToList();

    private Role(RoleId id, string name)
        : base(id)
    {
        Name = name;
    }
    public void AddPolicy (Policy policy)
    {
        if (_policies.Any(p => p.Id == policy.Id))
        {
            return;
        }
        _policies.Add(policy);
    }

    public void UpdatePolicies(List<Policy> policies)
    {
        _policies.Clear();
        _policies.AddRange(policies);
    }
    public static Role Create(string name)
    {
        return new Role(RoleId.CreateUnique(), name);
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private Role() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
