using ErrorOr;
using Lubricentro.Application.VehicleFactoryMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleFactoryMediator.Queries.GetAll;

public record GetAllVehicleFactoryQuery() : IRequest<ErrorOr<List<VehicleFactoryResult>>>
{
}
