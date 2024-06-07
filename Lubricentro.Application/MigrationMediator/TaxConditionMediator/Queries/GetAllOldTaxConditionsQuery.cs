using ErrorOr;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using MediatR;

namespace Lubricentro.Application.MigrationMediator.TaxConditionMediator.Queries;

public record GetAllOldTaxConditionsQuery : IRequest<ErrorOr<List<OldTaxConditionResult>>>
{
}
