using ErrorOr;
using Lubricentro.Application.BrandMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using MediatR;

namespace Lubricentro.Application.BrandMediator.Queries.GetAll;

internal class GetAllBrandsQueryHandler(IBrandRepository brandRepository) : IRequestHandler<GetAllBrandsQuery, ErrorOr<List<BrandResult>>>
{
    public async Task<ErrorOr<List<BrandResult>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await brandRepository.GetAllAsync();

        List<BrandResult> result = [];

        foreach (var brand in brands)
        {
            result.Add(new(brand));
        }

        return result;
    }
}
