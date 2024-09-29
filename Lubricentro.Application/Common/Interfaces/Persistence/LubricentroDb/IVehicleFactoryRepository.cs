using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IVehicleFactoryRepository : IRepository<VehicleFactory, VehicleFactoryId>
{
    public Task<IEnumerable<VehicleFactory>> GetVehicleFactoriesAsync();
    public bool LookUp(string name, VehicleFactoryId? vehicleFactoryId = null);
    public VehicleFactory? GetVehicleFactoryById(VehicleFactoryId vehicleFactoryId);
}
