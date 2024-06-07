using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.RoleAggregate.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IRoleRepository : IRepository<Role, RoleId>
{
    Task<Role?> GetByName(string name);
    Task<Role?> GetById(RoleId roleId);
    Task<List<Role>?> GetAll();
}
