using ErrorOr;
using Lubricentro.Application.BranchMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.BranchMediator.Queries.GetByCompanyId;

internal class GetByCompanyIdBranchQueryHandler(IBranchRepository branchRepository) : IRequestHandler<GetByCompanyIdBranchQuery, ErrorOr<List<BranchResult>>>
{
    public async Task<ErrorOr<List<BranchResult>>> Handle(GetByCompanyIdBranchQuery request, CancellationToken cancellationToken)
    { 
        var branches = await branchRepository.GetByCompany(CompanyId.Create(request.CompanyId));
        List<BranchResult> results = [];
        foreach(var branch in branches)
        {
            results.Add(new BranchResult(branch.Id.Value.ToString(),
                                        branch.Name,
                                        branch.PointOfSale,
                                        branch.Address.Country,
                                        branch.Address.State,
                                        branch.Address.City,
                                        branch.Address.Street,
                                        branch.Address.PostalCode));
        }
        return results;
    }
}
