using Lubricentro.Domain.PermissionAggregate;
using Lubricentro.Domain.PermissionAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence;

public interface IPermissionRepository : IRepository<Permission, PermissionId>
{

}
