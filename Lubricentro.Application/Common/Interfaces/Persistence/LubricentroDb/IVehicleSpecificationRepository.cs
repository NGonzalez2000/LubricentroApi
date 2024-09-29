using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;

namespace Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

public interface IVehicleSpecificationRepository : IRepository<VehicleSpecification, VehicleSpecificationId>
{
    public Task<IEnumerable<VehicleSpecification>> GetAllVehicleSpecifiationsAsync();
    public bool LookUp(string Specifiaction, VehicleSpecificationId? id = null);
    public VehicleSpecification? GetVehicleSpecificationById(VehicleSpecificationId id);
}
