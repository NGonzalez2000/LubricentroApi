using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.VehicleSpecificationMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.VehicleAggregates.Entities;
using MediatR;

namespace Lubricentro.Application.VehicleSpecificationMediator.Commands.Create;

internal class CreateVehicleSpecificationCommandHandler(IVehicleSpecificationRepository vehicleSpecificationRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateVehicleSpecificationCommand, ErrorOr<VehicleSpecificationResult>>
{
    public async Task<ErrorOr<VehicleSpecificationResult>> Handle(CreateVehicleSpecificationCommand request, CancellationToken cancellationToken)
    {
        if (vehicleSpecificationRepository.LookUp(request.Specification))
        {
            return Errors.VehicleSpecification.Duplicated;
        }

        var vehicleSpecification = VehicleSpecification.Create(request.Specification);

        vehicleSpecificationRepository.Add(vehicleSpecification);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new VehicleSpecificationResult(vehicleSpecification);
    }
}
