using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IVehicleModelRepository : IRepository<VehicleModel, VehicleModelId>
{
    public bool LookUp(string Name, VehicleModelId? vehicleModelId = null);
    public VehicleModel? GetVehicleModelById(VehicleModelId vehicleModelId);
    public Task<List<VehicleModel>> GetAllVehicleModelsAsync();
}
