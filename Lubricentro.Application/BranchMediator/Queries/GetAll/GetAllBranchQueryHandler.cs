using ErrorOr;
using Lubricentro.Application.BranchMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using MediatR;

namespace Lubricentro.Application.BranchMediator.Queries.GetAll;

internal class GetAllBranchQueryHandler(IBranchRepository branchRepository) : IRequestHandler<GetAllBranchQuery, ErrorOr<List<BranchResult>>>
{
    public async Task<ErrorOr<List<BranchResult>>> Handle(GetAllBranchQuery request, CancellationToken cancellationToken)
    {
        var branches = await branchRepository.GetAll();

        List<BranchResult> result = [];
        foreach (var branch in branches)
        {
            result.Add(new(branch.Id.Value.ToString(),
                                branch.Name,
                                branch.PointOfSale,
                                branch.Address.Country,
                                branch.Address.State,
                                branch.Address.City,
                                branch.Address.Street,
                                branch.Address.PostalCode));
        }

        return result;
    }
}
