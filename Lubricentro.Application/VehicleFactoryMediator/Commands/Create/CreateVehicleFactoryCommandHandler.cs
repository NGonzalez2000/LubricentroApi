using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.VehicleFactoryMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.VehicleAggregates.Entities;
using MediatR;

namespace Lubricentro.Application.VehicleFactoryMediator.Commands.Create;

internal class CreateVehicleFactoryCommandHandler(IVehicleFactoryRepository vehicleFactoryRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateVehicleFactoryCommand, ErrorOr<VehicleFactoryResult>>
{
    public async Task<ErrorOr<VehicleFactoryResult>> Handle(CreateVehicleFactoryCommand request, CancellationToken cancellationToken)
    {
        if (vehicleFactoryRepository.LookUp(request.Name))
        {
            return Errors.VehicleFactory.Duplicated;
        }

        var vehicleFactory = VehicleFactory.Create(request.Name);
        
        vehicleFactoryRepository.Add(vehicleFactory);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new VehicleFactoryResult(vehicleFactory);
    }
}
