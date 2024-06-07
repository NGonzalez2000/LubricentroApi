using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.RoleMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.PolicyAggregate.ValueObjects;
using Lubricentro.Domain.RoleAggregate;
using MediatR;

namespace Lubricentro.Application.RoleMediator.Command.Create;

public class CreateRoleCommandHandler(IRoleRepository roleRepository, IPolicyRepository permissionRepository,IUnitOfWork unitOfWork) : IRequestHandler<CreateRoleCommand, ErrorOr<RoleResult>>
{
    private readonly IRoleRepository _roleRepository = roleRepository;
    private readonly IPolicyRepository _permissionRepository = permissionRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<RoleResult>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        if(await _roleRepository.GetByName(request.Name) is not null)
        {
            return Errors.Roles.Duplicated;
        }

        Role role = Role.Create(request.Name);
        
        foreach (var guid in request.Policies)
        {
            if (await _permissionRepository.GetPolicyById(PolicyId.Create(guid)) is Policy policy)
            {
                role.AddPolicy(policy);
            }
        }

        _roleRepository.Add(role);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new RoleResult(role);
    }
}
