using ErrorOr;
using Lubricentro.Application.VehicleModelMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleModelMediator.Commands.Update;

public record UpdateVehicleModelCommand(Guid Id, string Name, bool IsLight) : IRequest<ErrorOr<VehicleModelResult>>
{
}
