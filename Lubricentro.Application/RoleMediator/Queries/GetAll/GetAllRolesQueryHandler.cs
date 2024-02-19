using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Application.RoleMediator.Common;
using Lubricentro.Domain.RoleAggregate;
using MediatR;

namespace Lubricentro.Application.RoleMediator.Queries.GetAll;

public class GetAllRolesQueryHandler(IRoleRepository roleRepository) : IRequestHandler<GetAllRolesQuery, ErrorOr<List<RoleResult>>>
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<ErrorOr<List<RoleResult>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        List<Role>? roles = await _roleRepository.GetAll();

        List<RoleResult> result = [];

        if(roles != null)
        {
            foreach( Role role in roles)
            {
                result.Add(new(role));
            }
        }

        return result;
    }
}
