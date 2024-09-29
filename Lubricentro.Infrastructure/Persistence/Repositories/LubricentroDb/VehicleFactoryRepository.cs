using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb
{
    internal class VehicleFactoryRepository(LubricentroDbContext dbContext) : Repository<VehicleFactory, VehicleFactoryId>(dbContext), IVehicleFactoryRepository
    {
        public async Task<IEnumerable<VehicleFactory>> GetVehicleFactoriesAsync()
        {
            return await DbContext.VehicleFactories.Include(vf => vf.Models).ToListAsync();
        }

        public VehicleFactory? GetVehicleFactoryById(VehicleFactoryId vehicleFactoryId)
        {
            return DbContext.VehicleFactories.Include(vf => vf.Models).SingleOrDefault(vf => vf.Id == vehicleFactoryId);
        }

        public bool LookUp(string name, VehicleFactoryId? vehicleFactoryId = null)
        {
            return vehicleFactoryId is not null ?
                DbContext.VehicleFactories.Any(vf => vf.Name == name && vf.Id != vehicleFactoryId) :
                DbContext.VehicleFactories.Any(vf => vf.Name == name);
        }
    }
}
