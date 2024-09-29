using ErrorOr;
using Lubricentro.Application.VehicleFactoryMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleFactoryMediator.Commands.Delete;

public record DeleteVehicleFactoryCommand(Guid Id) : IRequest<ErrorOr<VehicleFactoryResult>>
{
}
