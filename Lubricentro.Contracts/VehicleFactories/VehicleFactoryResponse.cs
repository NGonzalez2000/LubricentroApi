using Lubricentro.Contracts.VehicleModels;

namespace Lubricentro.Contracts.VehicleFactories;

public record VehicleFactoryResponse(string Id, string Name, List<VehicleModelResponse> Models)
{
}


