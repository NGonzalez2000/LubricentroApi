using ErrorOr;
using Lubricentro.Application.TaxConditionMediator.Common;
using MediatR;

namespace Lubricentro.Application.TaxConditionMediator.Commands.Create;

public record CreateTaxConditionCommand(string Description, char Type, bool Vat) : IRequest<ErrorOr<TaxConditionResult>>
{
}
