using ErrorOr;
using Lubricentro.Application.ClientMediator.Common;
using MediatR;

namespace Lubricentro.Application.ClientMediator.Commands.Update;

public record UpdateClientCommand(Guid Id,
                                  string Country,
                                  string State,
                                  string City,
                                  string Street,
                                  string PostalCode,
                                  Guid TaxConditionId,
                                  string ClientName,
                                  string Cuil,
                                  string Email,
                                  string PhoneNumber,
                                  string CellphoneNumber,
                                  string Observation,
                                  bool HasCheckingAccount,
                                  bool IsWholesaler) : IRequest<ErrorOr<ClientResult>>
{
}
