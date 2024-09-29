using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.VehicleModelMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using MediatR;

namespace Lubricentro.Application.VehicleModelMediator.Commands.Create;

internal class CreateVehicleModelCommandHandler(IVehicleFactoryRepository vehicleFactoryRepository, IVehicleModelRepository vehicleModelRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateVehicleModelCommand, ErrorOr<VehicleModelResult>>
{
    public async Task<ErrorOr<VehicleModelResult>> Handle(CreateVehicleModelCommand request, CancellationToken cancellationToken)
    {
        if (vehicleModelRepository.LookUp(request.Name))
        {
            return Errors.VehicleModel.Duplicated;
        }

        if (vehicleFactoryRepository.GetVehicleFactoryById(VehicleFactoryId.Create(request.VehicleFactoryId)) is not VehicleFactory vehicleFactory)
        {
            return Errors.VehicleFactory.NotFound;
        }

        var vehicleModel = VehicleModel.Create(request.Name, request.IsLight);
        vehicleFactory.AddVehicleModel(vehicleModel);

        vehicleFactoryRepository.Update(vehicleFactory);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new VehicleModelResult(vehicleModel);
    }
}
