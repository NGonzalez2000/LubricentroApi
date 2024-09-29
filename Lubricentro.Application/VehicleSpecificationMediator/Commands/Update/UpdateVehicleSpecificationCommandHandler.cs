using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.VehicleSpecificationMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.VehicleAggregates.Entities;
using Lubricentro.Domain.VehicleAggregates.ValueObjects;
using MediatR;

namespace Lubricentro.Application.VehicleSpecificationMediator.Commands.Update;

internal class UpdateVehicleSpecificationCommandHandler(IVehicleSpecificationRepository vehicleSpecificationRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateVehicleSpecificationCommand, ErrorOr<VehicleSpecificationResult>>
{
    public async Task<ErrorOr<VehicleSpecificationResult>> Handle(UpdateVehicleSpecificationCommand request, CancellationToken cancellationToken)
    {
        if(vehicleSpecificationRepository.LookUp(request.Specification, VehicleSpecificationId.Create(request.Id)))
        {
            return Errors.VehicleSpecification.Duplicated;
        }
        if(vehicleSpecificationRepository.GetVehicleSpecificationById(VehicleSpecificationId.Create(request.Id)) is not VehicleSpecification vehicleSpecification){
            return Errors.VehicleSpecification.NotFound;
        }

        vehicleSpecification.Update(request.Specification);
        vehicleSpecificationRepository.Update(vehicleSpecification);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new VehicleSpecificationResult(vehicleSpecification);
    }
}
