using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.VehicleModelMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using MediatR;

namespace Lubricentro.Application.VehicleModelMediator.Commands.Delete;

internal class DeleteVehicleModelCommandHandler(IVehicleModelRepository vehicleModelRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteVehicleModelCommand, ErrorOr<VehicleModelResult>>
{
    public async Task<ErrorOr<VehicleModelResult>> Handle(DeleteVehicleModelCommand request, CancellationToken cancellationToken)
    {
        if(vehicleModelRepository.GetVehicleModelById(VehicleModelId.Create(request.Id)) is not VehicleModel vehicleModel)
        {
            return Errors.VehicleModel.NotFound;
        }

        vehicleModelRepository.Delete(vehicleModel);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new VehicleModelResult(vehicleModel);
    }
}
