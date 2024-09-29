using ErrorOr;
using Lubricentro.Application.BrandMediator.Common;
using MediatR;

namespace Lubricentro.Application.BrandMediator.Commands.Create;

public record CreateBrandCommand(string Name, Guid ProviderId) : IRequest<ErrorOr<BrandResult>>
{
}
