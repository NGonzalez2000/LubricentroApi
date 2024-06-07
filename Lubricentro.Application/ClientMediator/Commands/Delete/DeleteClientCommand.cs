using ErrorOr;
using Lubricentro.Application.ClientMediator.Common;
using MediatR;

namespace Lubricentro.Application.ClientMediator.Commands.Delete;

public record DeleteClientCommand(Guid Id) : IRequest<ErrorOr<ClientResult>>
{
}
