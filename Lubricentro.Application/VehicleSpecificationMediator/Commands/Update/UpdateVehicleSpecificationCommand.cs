using ErrorOr;
using Lubricentro.Application.VehicleSpecificationMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleSpecificationMediator.Commands.Update;

public record UpdateVehicleSpecificationCommand(Guid Id, string Specification) : IRequest<ErrorOr<VehicleSpecificationResult>>
{
}
