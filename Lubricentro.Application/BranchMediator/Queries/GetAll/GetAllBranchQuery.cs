using ErrorOr;
using Lubricentro.Application.BranchMediator.Common;
using MediatR;

namespace Lubricentro.Application.BranchMediator.Queries.GetAll;

public record GetAllBranchQuery() : IRequest<ErrorOr<List<BranchResult>>>
{
}
