using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Application.RoleMediator.Common;
using MediatR;

namespace Lubricentro.Application.RoleMediator.Queries.GetAllPolicies;

internal class GetAllPoliciesQueryHandler(IPolicyRepository policyRepository) : IRequestHandler<GetAllPoliciesQuery, ErrorOr<List<PolicyResult>>>
{
    private readonly IPolicyRepository _policyRepository = policyRepository;
    public async Task<ErrorOr<List<PolicyResult>>> Handle(GetAllPoliciesQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var policies = _policyRepository.GetAll();

        List<PolicyResult> result = [];

        foreach(var policy in policies)
        {
            if(policy.Name != "CompanyPolicy" && policy.Name != "ServerPolicy")
            {
                result.Add(new(policy.Id.Value.ToString(), policy.Name));
            }
        }
        return result;
    }
}
