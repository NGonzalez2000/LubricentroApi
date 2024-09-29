using ErrorOr;
using Lubricentro.Application.ProductMediator.Common;
using MediatR;

namespace Lubricentro.Application.ProductMediator.Command.Delete;

public record DeleteProductCommand(Guid Id) : IRequest<ErrorOr<ProductResult>>
{
}
