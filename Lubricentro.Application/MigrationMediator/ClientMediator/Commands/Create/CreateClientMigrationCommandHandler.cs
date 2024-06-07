using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using Lubricentro.Domain.TaxConditionAggregate;
using MediatR;
using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using Lubricentro.Application.MigrationMediator.ClientMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;
using Lubricentro.Domain.MigrationAggregates;
using Microsoft.AspNetCore.Server.HttpSys;

namespace Lubricentro.Application.MigrationMediator.ClientMediator.Commands.Create;

internal class CreateClientMigrationCommandHandler(IClientRepository _clientRepository, ITaxConditionRepository _taxConditionRepository, IClientMigrationRepository _clientMigrationRepository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateClientMigrationCommand, ErrorOr<ClientMigrationResult>>
{
    public async Task<ErrorOr<ClientMigrationResult>> Handle(CreateClientMigrationCommand request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.Cuil) && _clientRepository.GetClientByCuil(request.Cuil) is not null)
        {
            return Errors.Clients.DuplicatedCuil;
        }

        if (_taxConditionRepository.GetById(TaxConditionId.Create(request.TaxConditionId)) is not TaxCondition taxCondition)
        {
            return Errors.TaxConditions.NotFound;
        }

        var address = Address.Create(request.Country, request.State, request.City, request.Street, request.PostalCode);

        var client = Client.Create(address, taxCondition, request.ClientName, request.Cuil, request.Email, request.PhoneNumber, request.CellphoneNumber, request.Observation, request.HasCheckingAccount, request.IsWholesaler);

        ClientMigration clientMigration = ClientMigration.Create(client.Id.Value.ToString(), int.Parse(request.Id));

        _clientRepository.Add(client);
        _clientMigrationRepository.Add(clientMigration); 

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var taxConditionResult = new TaxConditionMigrationResult(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT);

        return new ClientMigrationResult(client.Id.Value.ToString(), client.Address, taxConditionResult, client.ClientName, client.Cuil, client.Email, client.PhoneNumber, client.CellphoneNumber, client.Observation, client.HasCheckingAccount, client.IsWholesaler);
    }
}
