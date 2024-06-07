using ErrorOr;
using Lubricentro.Application.TaxConditionMediator.Common;
using MediatR;

namespace Lubricentro.Application.TaxConditionMediator.Commands.Update;

public record UpdateTaxConditionCommand(Guid Id, string Description, char Type, bool Vat) : IRequest<ErrorOr<TaxConditionResult>>
{
}
