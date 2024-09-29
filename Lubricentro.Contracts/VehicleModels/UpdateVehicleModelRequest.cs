namespace Lubricentro.Contracts.VehicleModels;

public record UpdateVehicleModelRequest(Guid Id, string Name, bool IsLight)
{
}
