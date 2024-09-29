using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.VehicleFactoryMediator.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubricentro.Application.VehicleFactoryMediator.Queries.GetAll
{
    internal class GetAllVehicleFactoryQueryHandler(IVehicleFactoryRepository vehicleFactoryRepository) : IRequestHandler<GetAllVehicleFactoryQuery, ErrorOr<List<VehicleFactoryResult>>>
    {
        public async Task<ErrorOr<List<VehicleFactoryResult>>> Handle(GetAllVehicleFactoryQuery request, CancellationToken cancellationToken)
        {
            var factories = await vehicleFactoryRepository.GetVehicleFactoriesAsync();
            List<VehicleFactoryResult> result = [];
            foreach (var factory in factories) 
            {
                result.Add(new VehicleFactoryResult(factory));
            }
            return result;
        }
    }
}
