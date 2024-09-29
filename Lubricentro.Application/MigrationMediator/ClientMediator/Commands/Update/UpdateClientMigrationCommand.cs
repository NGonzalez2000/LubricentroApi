using ErrorOr;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.MigrationMediator.ClientMediator.Common;
using Lubricentro.Application.PhoneMediator;
using MediatR;

namespace Lubricentro.Application.MigrationMediator.ClientMediator.Commands.Update;

public record UpdateClientMigrationCommand(string Id,
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
                                           bool IsWholesaler) : IRequest<ErrorOr<ClientMigrationResult>>
{
}
