using ErrorOr;
using Lubricentro.Application.BrandMediator.Common;
using MediatR;

namespace Lubricentro.Application.BrandMediator.Commands.Update;

public record UpdateBrandCommand(Guid Id, string Name, Guid ProviderId) : IRequest<ErrorOr<BrandResult>>
{
}
