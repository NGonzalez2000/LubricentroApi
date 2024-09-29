using ErrorOr;
using Lubricentro.Application.BranchMediator.Common;
using MediatR;

namespace Lubricentro.Application.BranchMediator.Commands.Delete;

public record DeleteBranchCommand(Guid Id) : IRequest<ErrorOr<BranchResult>>
{
}
