using ErrorOr;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using MediatR;

namespace Lubricentro.Application.MigrationMediator.TaxConditionMediator.Commands.Update;

public record UpdateTaxConditionMigrationCommand(Guid Id, string Description, char Type, bool Vat) : IRequest<ErrorOr<TaxConditionMigrationResult>>
{
}
