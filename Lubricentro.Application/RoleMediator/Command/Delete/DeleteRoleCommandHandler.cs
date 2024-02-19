using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Application.RoleMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.RoleAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.RoleMediator.Command.Delete;

public class DeleteRoleCommandHandler(IRoleRepository roleRepository,IUnitOfWork unitOfWork) : IRequestHandler<DeleteRoleCommand, ErrorOr<RoleResult>>
{
    private readonly IRoleRepository _roleRepository = roleRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<RoleResult>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        //get the role from the database
        Role? role = await _roleRepository.GetById(RoleId.Create(request.Id));

        if(role is null)
        {
            return Errors.Roles.NotFound;
        }

        _roleRepository.Delete(role);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new RoleResult(role);
    }
}
