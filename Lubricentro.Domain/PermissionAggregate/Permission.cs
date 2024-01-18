using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.PermissionAggregate.ValueObjects;

namespace Lubricentro.Domain.PermissionAggregate;

public class Permission : AggregateRoot<PermissionId,Guid>
{
    private Permission(PermissionId permissionId, string name) : base(permissionId)
    {
        Name = name;
    }

    public string Name { get; private set; } = null!;
    public static Permission Create(PermissionId permissionId, string name)
    {
        return new Permission(permissionId, name);
    }
    private Permission() { }
}
