using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.VehicleModelMediator.Common;
using MediatR;

namespace Lubricentro.Application.VehicleModelMediator.Queries.GetAll;

internal class GetAllVehicleModelQueryHandler(IVehicleModelRepository vehicleModelRepository) : IRequestHandler<GetAllVehicleModelQuery, ErrorOr<List<VehicleModelResult>>>
{
    public async Task<ErrorOr<List<VehicleModelResult>>> Handle(GetAllVehicleModelQuery request, CancellationToken cancellationToken)
    {
        var vehicleModels = await vehicleModelRepository.GetAllVehicleModelsAsync();
        List<VehicleModelResult> result = [];
        foreach (var vehicleModel in vehicleModels)
        {
            result.Add(new VehicleModelResult(vehicleModel));
        }

        return result;
    }
}
