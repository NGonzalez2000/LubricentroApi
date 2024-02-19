using ErrorOr;
using Lubricentro.Application.RoleMediator.Common;
using MediatR;

namespace Lubricentro.Application.RoleMediator.Queries.GetAll;

public record GetAllRolesQuery() : IRequest<ErrorOr<List<RoleResult>>>;
