using ErrorOr;
using Lubricentro.Application.ProviderMediator.Common;
using MediatR;

namespace Lubricentro.Application.ProviderMediator.Command.Delete;

public record DeleteProviderCommand(Guid Id) : IRequest<ErrorOr<ProviderResult>>
{
}
