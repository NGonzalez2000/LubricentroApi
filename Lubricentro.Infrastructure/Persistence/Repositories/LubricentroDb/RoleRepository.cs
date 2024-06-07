using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.RoleAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb
{
    public class RoleRepository(LubricentroDbContext dbContext) : Repository<Role, RoleId>(dbContext), IRoleRepository
    {
        public async Task<List<Role>?> GetAll()
        {
            return await DbContext.Roles.Include(r => r.Policies).Where(r => r.Name != "Admin").ToListAsync();
        }

        public async Task<Role?> GetById(RoleId roleId)
        {
            return await DbContext.Roles.Include(r => r.Policies).FirstOrDefaultAsync(r => r.Id == roleId);
        }

        public async Task<Role?> GetByName(string name)
        {
            return await DbContext.Roles.FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
