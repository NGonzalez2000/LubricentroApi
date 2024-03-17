using ErrorOr;
using Lubricentro.Application.RoleMediator.Common;
using MediatR;

namespace Lubricentro.Application.RoleMediator.Queries.GetAllPolicies;

public record GetAllPoliciesQuery : IRequest<ErrorOr<List<PolicyResult>>>
{
}
