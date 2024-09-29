using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.VehicleSpecificationMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleSpecificationMediator.Queries.GetAll;

internal class GetAllVehicleSpecificationQueryHandler(IVehicleSpecificationRepository vehicleSpecificationRepository) : IRequestHandler<GetAllVehicleSpecificationQuery, ErrorOr<List<VehicleSpecificationResult>>>
{
    public async Task<ErrorOr<List<VehicleSpecificationResult>>> Handle(GetAllVehicleSpecificationQuery request, CancellationToken cancellationToken)
    {
        var vehicleSpecifications = await vehicleSpecificationRepository.GetAllVehicleSpecifiationsAsync();
        List<VehicleSpecificationResult> result = [];
        foreach(var vehicleSpecification in vehicleSpecifications)
        {
            result.Add(new VehicleSpecificationResult(vehicleSpecification));
        }

        return result;
    }
}
