using ErrorOr;
using Lubricentro.Application.TaxConditionMediator.Common;
using MediatR;

namespace Lubricentro.Application.TaxConditionMediator.Queries.GetAll;

public record GetTaxConditionsQuery() : IRequest<ErrorOr<List<TaxConditionResult>>>
{
}
