using ErrorOr;
using Lubricentro.Application.ClientMediator.Common;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.PhoneMediator;
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
                                  bool HasEmailNotification,
                                  List<EmailCommand> Emails,
                                  bool HasPhoneNotification,
                                  List<PhoneCommand> Phones,
                                  string Observation,
                                  bool HasCheckingAccount,
                                  bool IsWholesaler) : IRequest<ErrorOr<ClientResult>>
{
}
