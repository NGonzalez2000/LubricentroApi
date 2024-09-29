using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;

internal class VehicleModelRepository(LubricentroDbContext dbContext) : Repository<VehicleModel, VehicleModelId>(dbContext), IVehicleModelRepository
{
    public async Task<List<VehicleModel>> GetAllVehicleModelsAsync()
    {
        return await DbContext.VehicleModels.ToListAsync();
    }

    public VehicleModel? GetVehicleModelById(VehicleModelId vehicleModelId)
    {
        return DbContext.VehicleModels.SingleOrDefault(vm => vm.Id == vehicleModelId);
    }

    public bool LookUp(string Name, VehicleModelId? vehicleModelId = null)
    {
        return vehicleModelId is null ?
            DbContext.VehicleModels.Any(vm => vm.Name == Name) :
            DbContext.VehicleModels.Any(vm => vm.Name == Name && vm.Id != vehicleModelId);

    }
}
