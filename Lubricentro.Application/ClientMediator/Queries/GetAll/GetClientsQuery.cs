using ErrorOr;
using Lubricentro.Application.ClientMediator.Common;
using MediatR;

namespace Lubricentro.Application.ClientMediator.Queries.GetAll;

public record GetClientsQuery : IRequest<ErrorOr<List<ClientResult>>>
{
}
