using ErrorOr;
using Lubricentro.Application.RoleMediator.Common;
using MediatR;

namespace Lubricentro.Application.RoleMediator.Command.Create;

public record CreateRoleCommand(string Name, List<Guid> Policies) : IRequest<ErrorOr<RoleResult>>;
