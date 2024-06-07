using ErrorOr;
using Lubricentro.Application.CompanyMediator.Common;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Queries.GetServices;

public class GetAllCompanyServicesQuery : IRequest<ErrorOr<List<CompanyServiceResult>>>
{
}
