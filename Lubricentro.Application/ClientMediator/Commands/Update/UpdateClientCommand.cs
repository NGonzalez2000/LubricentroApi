using ErrorOr;
using Lubricentro.Application.ClientMediator.Common;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.PhoneMediator;
using Lubricentro.Domain.EmailAggregates;
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
                                  bool HasEmailNotification,
                                  List<EmailCommand> Emails,
                                  bool HasPhoneNotification,
                                  List<PhoneCommand> Phones,
                                  string Observation,
                                  bool HasCheckingAccount,
                                  bool IsWholesaler) : IRequest<ErrorOr<ClientResult>>
{
}
