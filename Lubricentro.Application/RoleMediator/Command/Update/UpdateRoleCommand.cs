using ErrorOr;
using Lubricentro.Application.RoleMediator.Common;
using Lubricentro.Domain.PolicyAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.RoleMediator.Command.Update;

public record UpdateRoleCommand(Guid Id,string Name, List<Guid> PolicyIds) : IRequest<ErrorOr<RoleResult>>
{ }
