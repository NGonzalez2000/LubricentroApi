using ErrorOr;
using Lubricentro.Application.ProviderMediator.Common;
using MediatR;

namespace Lubricentro.Application.ProviderMediator.Queries;

public record GetAllProvidersQuery : IRequest<ErrorOr<List<ProviderResult>>>
{
}
