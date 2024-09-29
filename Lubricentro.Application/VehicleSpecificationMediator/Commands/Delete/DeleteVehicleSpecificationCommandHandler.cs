using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.VehicleSpecificationMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using MediatR;

namespace Lubricentro.Application.VehicleSpecificationMediator.Commands.Delete;

internal class DeleteVehicleSpecificationCommandHandler(IVehicleSpecificationRepository vehicleSpecificationRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteVehicleSpecificationCommand, ErrorOr<VehicleSpecificationResult>>
{
    public async Task<ErrorOr<VehicleSpecificationResult>> Handle(DeleteVehicleSpecificationCommand request, CancellationToken cancellationToken)
    {
        if(vehicleSpecificationRepository.GetVehicleSpecificationById(VehicleSpecificationId.Create(request.Id)) is not VehicleSpecification vehicleSpecification)
        {
            return Errors.VehicleSpecification.NotFound;
        }

        vehicleSpecificationRepository.Delete(vehicleSpecification);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new VehicleSpecificationResult(vehicleSpecification);
    }
}
