using ErrorOr;
using Lubricentro.Application.TaxConditionMediator.Common;
using MediatR;

namespace Lubricentro.Application.TaxConditionMediator.Commands.Delete;

public record DeleteTaxConditionCommand(Guid Id) : IRequest<ErrorOr<TaxConditionResult>>
{
}
