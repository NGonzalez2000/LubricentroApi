using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;
using Lubricentro.Application.MigrationMediator.ClientMediator.Common;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Domain.ClientAggregate.ValueObjects;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.MigrationMediator.ClientMediator.Commands.Update;

internal class UpdateClientMigrationCommandHandler(IClientMigrationRepository _clientMigrationRepository, IClientRepository _clientRepository, ITaxConditionRepository _taxConditionRepository, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateClientMigrationCommand, ErrorOr<ClientMigrationResult>>
{
    public async Task<ErrorOr<ClientMigrationResult>> Handle(UpdateClientMigrationCommand request, CancellationToken cancellationToken)
    {
        if(_clientRepository.GetClientById(ClientId.Create(new(request.Id))) is not Client client)
        {
            var clientMigration = await _clientMigrationRepository.GetByClientId(request.Id);
            if(clientMigration is null)
            {
                return Errors.Clients.NotFounnd;
            }
            _clientMigrationRepository.Delete(clientMigration);
            return Errors.Clients.NotFounnd;
        }

        if(!string.IsNullOrEmpty(client.Cuil) && _clientRepository.GetClientByCuil(client.Cuil) is Client temp && temp.Id != client.Id)
        {
            return Errors.Clients.DuplicatedCuil;
        }

        var taxCondition = _taxConditionRepository.GetById(TaxConditionId.Create(request.TaxConditionId));

        if(taxCondition is null)
        {
            return Errors.TaxConditions.NotFound;
        }



        client.Update(request.Country, request.State, request.City, request.Street, request.PostalCode, taxCondition, request.ClientName, request.Cuil, request.Email,
            request.PhoneNumber, request.CellphoneNumber, request.Observation, request.HasCheckingAccount, request.IsWholesaler);

        _clientRepository.Update(client);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var taxConditionResult = new TaxConditionMigrationResult(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT);

        return new ClientMigrationResult(client.Id.Value.ToString(), client.Address, taxConditionResult, client.ClientName, client.Cuil, client.Email, client.PhoneNumber, client.CellphoneNumber, client.Observation, client.HasCheckingAccount, client.IsWholesaler);

    }
}
