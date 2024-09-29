using ErrorOr;
using Lubricentro.Application.BranchMediator.Common;
using MediatR;

namespace Lubricentro.Application.BranchMediator.Queries.GetByCompanyId;

public record GetByCompanyIdBranchQuery(Guid CompanyId) : IRequest<ErrorOr<List<BranchResult>>>
{
}
