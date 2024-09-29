using ErrorOr;
using Lubricentro.Application.VehicleFactoryMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleFactoryMediator.Commands.Create;

public record CreateVehicleFactoryCommand(string Name) : IRequest<ErrorOr<VehicleFactoryResult>>
{
}
