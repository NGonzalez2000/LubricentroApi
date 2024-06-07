using ErrorOr;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using MediatR;

namespace Lubricentro.Application.MigrationMediator.TaxConditionMediator.Commands.Create;

public record CreateTaxConditionMigrationCommand(string OldId, string Description, char Type, bool Vat) : IRequest<ErrorOr<TaxConditionMigrationResult>>
{
}
