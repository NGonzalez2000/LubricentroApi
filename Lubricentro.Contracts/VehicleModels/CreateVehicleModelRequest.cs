namespace Lubricentro.Contracts.VehicleModels;

public record CreateVehicleModelRequest(Guid VehicleFactoryId, string Name, bool IsLight)
{
}
