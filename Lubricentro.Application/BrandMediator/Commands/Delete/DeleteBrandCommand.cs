using ErrorOr;
using Lubricentro.Application.BrandMediator.Common;
using MediatR;

namespace Lubricentro.Application.BrandMediator.Commands.Delete;

public record DeleteBrandCommand(Guid Id) : IRequest<ErrorOr<BrandResult>>
{
}
