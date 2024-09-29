using ErrorOr;
using Lubricentro.Application.BranchMediator.Common;
using MediatR;

namespace Lubricentro.Application.BranchMediator.Commands.Create;

public record CreateBranchCommand(Guid CompanyId, string Name, string PointOfSale, string Country, string State, string City, string Street, string PostalCode) : IRequest<ErrorOr<BranchResult>>
{
}
