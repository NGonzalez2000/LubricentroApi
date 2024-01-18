using Microsoft.AspNetCore.Authorization;

namespace Lubricentro.Infrastructure.Authorization;

public class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}
