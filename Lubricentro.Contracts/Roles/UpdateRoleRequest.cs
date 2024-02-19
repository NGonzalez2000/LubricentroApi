namespace Lubricentro.Contracts.Roles;

public record UpdateRoleRequest(Guid Id, string Name, List<Guid> PolicyIds);