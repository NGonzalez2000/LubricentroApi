using ErrorOr;
using Lubricentro.Application.BranchMediator.Common;
using MediatR;

namespace Lubricentro.Application.BranchMediator.Commands.Update;

public record UpdateBranchCommand(Guid Id, string Name, string PointOfSale, string Country, string State, string City ,string Street, string PostalCode) : IRequest<ErrorOr<BranchResult>>
{
}
