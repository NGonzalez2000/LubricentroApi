using ErrorOr;
using Lubricentro.Application.MigrationMediator.ClientMediator.Common;
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
                                           string Email,
                                           string PhoneNumber,
                                           string CellphoneNumber,
                                           string Observation,
                                           bool HasCheckingAccount,
                                           bool IsWholesaler) : IRequest<ErrorOr<ClientMigrationResult>>
{
}
