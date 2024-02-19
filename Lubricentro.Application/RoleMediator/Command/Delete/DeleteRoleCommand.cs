using ErrorOr;
using Lubricentro.Application.RoleMediator.Common;
using MediatR;

namespace Lubricentro.Application.RoleMediator.Command.Delete;

public record DeleteRoleCommand(Guid Id) : IRequest<ErrorOr<RoleResult>> { }
