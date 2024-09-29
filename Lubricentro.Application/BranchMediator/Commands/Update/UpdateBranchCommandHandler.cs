using ErrorOr;
using Lubricentro.Application.BranchMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.BranchMediator.Commands.Update;

internal class UpdateBranchCommandHandler(IBranchRepository branchRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateBranchCommand, ErrorOr<BranchResult>>
{
    public async Task<ErrorOr<BranchResult>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        if(await branchRepository.AlreadyExists(request.PointOfSale, BranchId.Create(request.Id)))
        {
            return Errors.Branches.DuplicatedPointOfSale;
        }

        if(await branchRepository.GetById(BranchId.Create(request.Id)) is not Branch branch)
        {
            return Errors.Branches.NotFound;
        }

        branch.Update(request.Name, request.PointOfSale, request.Country, request.State, request.City, request.Street, request.PostalCode);

        branchRepository.Update(branch);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new BranchResult(branch.Id.Value.ToString(),
                                branch.Name,
                                branch.PointOfSale,
                                branch.Address.Country,
                                branch.Address.State,
                                branch.Address.City,
                                branch.Address.Street,
                                branch.Address.PostalCode);
    }
}
