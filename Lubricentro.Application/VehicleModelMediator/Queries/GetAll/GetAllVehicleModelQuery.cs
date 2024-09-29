using ErrorOr;
using Lubricentro.Application.VehicleModelMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleModelMediator.Queries.GetAll;

public record GetAllVehicleModelQuery() : IRequest<ErrorOr<List<VehicleModelResult>>>
{
}
