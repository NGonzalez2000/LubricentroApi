using ErrorOr;
using Lubricentro.Application.VehicleModelMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleModelMediator.Commands.Create;

public record CreateVehicleModelCommand(Guid VehicleFactoryId, string Name, bool IsLight) : IRequest<ErrorOr<VehicleModelResult>>
{
}
