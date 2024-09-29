using ErrorOr;
using Lubricentro.Application.VehicleModelMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleModelMediator.Commands.Delete;

public record DeleteVehicleModelCommand(Guid Id) : IRequest<ErrorOr<VehicleModelResult>>
{
}
