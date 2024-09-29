using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.VehicleFactoryMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using MediatR;

namespace Lubricentro.Application.VehicleFactoryMediator.Commands.Update;

internal class UpdateVehicleFactoryCommandHandler(IVehicleFactoryRepository vehicleFactoryRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateVehicleFactoryCommand, ErrorOr<VehicleFactoryResult>>
{
    public async Task<ErrorOr<VehicleFactoryResult>> Handle(UpdateVehicleFactoryCommand request, CancellationToken cancellationToken)
    {
        if(vehicleFactoryRepository.LookUp(request.Name, VehicleFactoryId.Create(request.Id)))
        {
            return Errors.VehicleFactory.Duplicated;
        }

        if(vehicleFactoryRepository.GetVehicleFactoryById(VehicleFactoryId.Create(request.Id)) is not VehicleFactory vehicleFactory)
        {
            return Errors.VehicleFactory.NotFound;
        }

        vehicleFactory.Update(request.Name);
        vehicleFactoryRepository.Update(vehicleFactory);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new VehicleFactoryResult(vehicleFactory);
    }
}
