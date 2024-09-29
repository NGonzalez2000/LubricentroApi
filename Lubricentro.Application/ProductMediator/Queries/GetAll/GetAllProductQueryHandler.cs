using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.ProductMediator.Common;
using MediatR;

namespace Lubricentro.Application.ProductMediator.Queries.GetAll;

internal class GetAllProductQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductQuery, ErrorOr<List<ProductResult>>>
{
    public async Task<ErrorOr<List<ProductResult>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllAsync();

        List<ProductResult> results = [];
        foreach (var product in products)
        {
            results.Add(new ProductResult(product));
        }
        return results;
    }
}
