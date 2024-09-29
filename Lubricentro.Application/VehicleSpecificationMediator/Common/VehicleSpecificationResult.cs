using Lubricentro.Domain.VehicleAggregates.Entities;

namespace Lubricentro.Application.VehicleSpecificationMediator.Common;

public record VehicleSpecificationResult(string Id, string Specification)
{
    public VehicleSpecificationResult(VehicleSpecification vehicleSpecification) : this(vehicleSpecification.Id.Value.ToString(), vehicleSpecification.Specification) {}
}
