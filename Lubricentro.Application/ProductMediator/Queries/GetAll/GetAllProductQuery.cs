using ErrorOr;
using Lubricentro.Application.ProductMediator.Common;
using MediatR;

namespace Lubricentro.Application.ProductMediator.Queries.GetAll;

public record GetAllProductQuery() : IRequest<ErrorOr<List<ProductResult>>>
{
}
