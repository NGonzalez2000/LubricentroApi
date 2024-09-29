using Lubricentro.Application.VehicleModelMediator.Common;
using Lubricentro.Domain.VehicleAggregates.Entities;

namespace Lubricentro.Application.VehicleFactoryMediator.Common;

public record VehicleFactoryResult(string Id, string Name, List<VehicleModelResult> Models)
{
    public VehicleFactoryResult(VehicleFactory vehicleFactory) : this(vehicleFactory.Id.Value.ToString(), vehicleFactory.Name, [])
    { 
        foreach(var model in vehicleFactory.Models)
            Models.Add(new(model));
    }
}
