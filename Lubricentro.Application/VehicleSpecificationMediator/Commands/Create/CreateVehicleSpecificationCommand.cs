using ErrorOr;
using Lubricentro.Application.VehicleSpecificationMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleSpecificationMediator.Commands.Create;

public record CreateVehicleSpecificationCommand(string Specification) : IRequest<ErrorOr<VehicleSpecificationResult>>
{
}
