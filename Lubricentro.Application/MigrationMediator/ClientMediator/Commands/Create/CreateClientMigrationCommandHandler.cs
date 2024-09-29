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
using Lubricentro.Domain.EmailAggregates;
using Lubricentro.Domain.PhoneAggregate;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.PhoneMediator;

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

        List<Email> emails = [];
        foreach (var email in request.Emails)
        {
            emails.Add(Email.Create(email.Value, email.IsActive));
        }
        List<Phone> phones = [];
        foreach (var phone in request.Phones)
        {
            phones.Add(Phone.Create(phone.NationalId, phone.Value, phone.IsActive));
        }
        var client = Client.Create(address, taxCondition, request.ClientName, request.Cuil, request.HasEmailNotification, emails, request.HasPhoneNotifications, phones, request.Observation, request.HasCheckingAccount, request.IsWholesaler);

        ClientMigration clientMigration = ClientMigration.Create(client.Id.Value.ToString(), int.Parse(request.Id));

        _clientRepository.Add(client);
        _clientMigrationRepository.Add(clientMigration); 

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
