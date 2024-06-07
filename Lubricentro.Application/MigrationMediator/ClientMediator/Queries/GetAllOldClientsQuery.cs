using ErrorOr;
using Lubricentro.Application.MigrationMediator.ClientMediator.Common;
using MediatR;

namespace Lubricentro.Application.MigrationMediator.ClientMediator.Queries;

public record GetAllOldClientsQuery() : IRequest<ErrorOr<List<OldClientResult>>>
{
}
