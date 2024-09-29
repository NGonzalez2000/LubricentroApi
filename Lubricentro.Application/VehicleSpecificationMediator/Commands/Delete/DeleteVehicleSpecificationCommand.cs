using ErrorOr;
using Lubricentro.Application.VehicleSpecificationMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleSpecificationMediator.Commands.Delete;

public record DeleteVehicleSpecificationCommand(Guid Id) : IRequest<ErrorOr<VehicleSpecificationResult>>
{
}
