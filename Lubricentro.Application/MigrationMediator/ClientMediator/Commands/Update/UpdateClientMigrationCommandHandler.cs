using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.MigrationMediator.ClientMediator.Common;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using Lubricentro.Application.PhoneMediator;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Domain.ClientAggregate.ValueObjects;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.EmailAggregates;
using Lubricentro.Domain.PhoneAggregate;
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

        if(!string.IsNullOrEmpty(client.Cuil) && _clientRepository.GetClientByCuil(client.Cuil) is Client tempClient && tempClient.Id != client.Id)
        {
            return Errors.Clients.DuplicatedCuil;
        }

        var taxCondition = _taxConditionRepository.GetById(TaxConditionId.Create(request.TaxConditionId));

        if(taxCondition is null)
        {
            return Errors.TaxConditions.NotFound;
        }



        client.Update(request.Country, request.State, request.City, request.Street, request.PostalCode, taxCondition, request.ClientName, request.Cuil, request.HasEmailNotification, request.HasPhoneNotification, request.Observation, request.HasCheckingAccount, request.IsWholesaler);


        int i = 0;
        while(i < client.Emails.Count)
        {
            Email temp = client.Emails[i];
            if (!request.Emails.Any(x => x.Id == temp.Id.Value))
            {
                client.DeleteEmail(i);
            }
            else i++;
        }
        
        foreach (EmailCommand temp in request.Emails)
        {
            if (temp.Id == Guid.Empty)
            {
                client.AddEmail(Email.Create(temp.Value, temp.IsActive));
            }
            else
            {
                client.UpdateEmail(temp.Id, temp.Value, temp.IsActive);
            }
        }

        i = 0;
        while(i < client.Phones.Count)
        {
            Phone temp = client.Phones[i];
            if (!request.Phones.Any(x => x.Id == temp.Id.Value))
            {
                client.DeletePhone(i);
            }
            else i++;
        }

        foreach (PhoneCommand temp in request.Phones)
        {
            if (temp.Id == Guid.Empty)
            {
                client.AddPhone(Phone.Create(temp.NationalId, temp.Value, temp.IsActive));
            }
            else
            {
                client.UpdatePhone(temp.Id, temp.NationalId, temp.Value, temp.IsActive);
            }
        }

        _clientRepository.Update(client);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var taxConditionResult = new TaxConditionMigrationResult(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT);
        var emailResults = new List<EmailResult>();
        foreach (var email in client.Emails)
        {
            emailResults.Add(new EmailResult(email.Id.Value.ToString(), email.Value, email.IsActive));
        }
        var phoneResults = new List<PhoneResult>();
        foreach (var phone in client.Phones)
        {
            phoneResults.Add(new PhoneResult(phone.Id.Value.ToString(),phone.NationalId, phone.Value, phone.IsActive));
        }

        return new ClientMigrationResult(client.Id.Value.ToString(), client.Address, taxConditionResult, client.ClientName, client.Cuil, client.HasEmailNotification, emailResults, client.HasPhoneNotification, phoneResults, client.Observation, client.HasCheckingAccount, client.IsWholesaler);

    }
}
