using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Application.RoleMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.PolicyAggregate.ValueObjects;
using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.RoleAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.RoleMediator.Command.Update;

public class UpdateRoleCommandHandler(IRoleRepository roleRepository,IPolicyRepository policyRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateRoleCommand, ErrorOr<RoleResult>>
{
    private readonly IRoleRepository _roleRepository = roleRepository;
    private readonly IPolicyRepository _policyRepository = policyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<RoleResult>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        Role? role = await _roleRepository.GetById(RoleId.Create(request.Id));
        if (role is null) 
        {
            return Errors.Roles.NotFound; 
        }


        List<Policy> policies = []; 
        foreach (Guid guid in request.PolicyIds)
        {
            Policy? policy = await _policyRepository.GetPolicyById(PolicyId.Create(guid));
            if (policy is null) 
            {
                return Errors.Policies.NotFound;
            }
            policies.Add(policy);


        };

        role.Name = request.Name;
        role.UpdatePolicies(policies);


        _roleRepository.Update(role);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new RoleResult(role);

    }
}
