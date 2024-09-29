using Lubricentro.Domain.VehicleAggregates.Entities;

namespace Lubricentro.Application.VehicleModelMediator.Common;

public record VehicleModelResult(string Id, string Name, bool IsLight)
{
    public VehicleModelResult(VehicleModel vehicleModel) : this(vehicleModel.Id.Value.ToString(), vehicleModel.Name, vehicleModel.IsLight)
    { }
}
