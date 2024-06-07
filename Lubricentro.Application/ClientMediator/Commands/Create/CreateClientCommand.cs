using ErrorOr;
using Lubricentro.Application.ClientMediator.Common;
using Lubricentro.Domain.AddressAggregate;
using MediatR;

namespace Lubricentro.Application.ClientMediator.Commands.Create;

public record CreateClientCommand(string Country,
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
