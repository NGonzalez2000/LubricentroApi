using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Domain.PermissionAggregate;
using Lubricentro.Domain.PermissionAggregate.ValueObjects;

namespace Lubricentro.Infrastructure.Persistence.Repositories;

public class PermissionRepository(LubricentroDbContext dbContext) : Repository<Permission, PermissionId>(dbContext), IPermissionRepository
{
}
