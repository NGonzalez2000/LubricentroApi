namespace Lubricentro.Contracts.Roles;

public record CreateRoleRequest(string Name, List<Guid> Policies);