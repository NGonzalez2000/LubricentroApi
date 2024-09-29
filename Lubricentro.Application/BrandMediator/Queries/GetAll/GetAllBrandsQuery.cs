using ErrorOr;
using Lubricentro.Application.BrandMediator.Common;
using MediatR;

namespace Lubricentro.Application.BrandMediator.Queries.GetAll;

public record GetAllBrandsQuery : IRequest<ErrorOr<List<BrandResult>>>
{
}
