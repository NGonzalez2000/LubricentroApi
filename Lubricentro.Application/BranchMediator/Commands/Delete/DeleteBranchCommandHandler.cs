using ErrorOr;
using Lubricentro.Application.BranchMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.BranchMediator.Commands.Delete;

internal class DeleteBranchCommandHandler(IBranchRepository branchRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteBranchCommand, ErrorOr<BranchResult>>
{
    public async Task<ErrorOr<BranchResult>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        if(await branchRepository.GetById(BranchId.Create(request.Id)) is not Branch branch)
        {
            return Errors.Branches.NotFound;
        }

        branchRepository.Delete(branch);
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
