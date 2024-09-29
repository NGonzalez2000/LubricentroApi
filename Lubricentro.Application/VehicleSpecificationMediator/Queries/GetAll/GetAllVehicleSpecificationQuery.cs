using ErrorOr;
using Lubricentro.Application.VehicleSpecificationMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleSpecificationMediator.Queries.GetAll;

public record GetAllVehicleSpecificationQuery() : IRequest<ErrorOr<List<VehicleSpecificationResult>>>
{
}
