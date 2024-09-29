using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.VehicleFactoryMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using MediatR;

namespace Lubricentro.Application.VehicleFactoryMediator.Commands.Delete;

internal class DeleteVehicleFactoryCommandHandler(IVehicleFactoryRepository vehicleFactoryRepository,IVehicleModelRepository vehicleModelRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteVehicleFactoryCommand, ErrorOr<VehicleFactoryResult>>
{
    public async Task<ErrorOr<VehicleFactoryResult>> Handle(DeleteVehicleFactoryCommand request, CancellationToken cancellationToken)
    {
        if(vehicleFactoryRepository.GetVehicleFactoryById(VehicleFactoryId.Create(request.Id)) is not VehicleFactory vehicleFactory)
        {
            return Errors.VehicleFactory.NotFound;
        }

        foreach (VehicleModel vehicleModel in vehicleFactory.Models)
        {
            vehicleModelRepository.Delete(vehicleModel);
        }
        vehicleFactoryRepository.Delete(vehicleFactory);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new VehicleFactoryResult(vehicleFactory);
    }
}
