using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.VehicleModelMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using MediatR;

namespace Lubricentro.Application.VehicleModelMediator.Commands.Update;

internal class UpdateVehicleModelCommandHandler(IVehicleModelRepository vehicleModelRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateVehicleModelCommand, ErrorOr<VehicleModelResult>>
{
    public async Task<ErrorOr<VehicleModelResult>> Handle(UpdateVehicleModelCommand request, CancellationToken cancellationToken)
    {
        if(vehicleModelRepository.LookUp(request.Name, VehicleModelId.Create(request.Id)))
        {
            return Errors.VehicleModel.Duplicated;
        }
        if(vehicleModelRepository.GetVehicleModelById(VehicleModelId.Create(request.Id)) is not VehicleModel vehicleModel)
        {
            return Errors.VehicleModel.NotFound;
        }

        vehicleModel.Update(request.Name, request.IsLight);
        vehicleModelRepository.Update(vehicleModel);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new VehicleModelResult(vehicleModel);
    }
}
