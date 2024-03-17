using ErrorOr;
using Lubricentro.Application.CompanyMediator.Common;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Queries.GetAll;

public record GetAllCompaniesQuery() : IRequest<ErrorOr<List<CompanyResult>>>
{
}
