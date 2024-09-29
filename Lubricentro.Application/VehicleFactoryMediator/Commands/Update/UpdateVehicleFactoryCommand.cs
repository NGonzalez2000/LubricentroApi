using ErrorOr;
using Lubricentro.Application.VehicleFactoryMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleFactoryMediator.Commands.Update;

public record UpdateVehicleFactoryCommand(Guid Id, string Name) : IRequest<ErrorOr<VehicleFactoryResult>>
{
}
