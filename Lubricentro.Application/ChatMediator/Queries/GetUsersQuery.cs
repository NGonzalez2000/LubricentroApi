using ErrorOr;
using Lubricentro.Application.ChatMediator.Common;
using MediatR;

namespace Lubricentro.Application.ChatMediator.Queries;

public record GetUsersQuery(string Id) : IRequest<ErrorOr<List<UserResult>>>
{
}
