using ErrorOr;
using Lubricentro.Application.ClientMediator.Common;
using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Domain.ClientAggregate.ValueObjects;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using Lubricentro.Domain.TaxConditionAggregate;
using MediatR;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.PhoneMediator;
using Lubricentro.Domain.EmailAggregates;
using Lubricentro.Domain.PhoneAggregate;

namespace Lubricentro.Application.ClientMediator.Commands.Update;

internal class UpdateClientCommandHandler(IClientRepository clientRepository, ITaxConditionRepository taxConditionRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateClientCommand, ErrorOr<ClientResult>>
{
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly ITaxConditionRepository _taxConditionRepository = taxConditionRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<ClientResult>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        if(_clientRepository.GetClientById(ClientId.Create(request.Id)) is not Client client)
        {
            return Errors.Clients.NotFounnd;
        }

        if (_taxConditionRepository.GetById(TaxConditionId.Create(request.TaxConditionId)) is not TaxCondition taxCondition)
        {
            return Errors.TaxConditions.NotFound;
        }

        client.Update(request.Country, request.State, request.City, request.Street, request.PostalCode, taxCondition, request.ClientName, request.Cuil, request.HasEmailNotification, request.HasPhoneNotification,request.Observation, request.HasCheckingAccount, request.IsWholesaler);

        int i = 0;
        while (i < client.Emails.Count)
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
            if(temp.Id == Guid.Empty)
            {
                client.AddEmail(Email.Create(temp.Value, temp.IsActive));
            }
            else
            {
                client.UpdateEmail(temp.Id, temp.Value, temp.IsActive);
            }
        }

        i = 0;
        while (i < client.Phones.Count)
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

        var taxConditionResult = new TaxConditionResult(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT);
        
        var emailsResult = new List<EmailResult>();
        foreach (var email in client.Emails)
        {
            emailsResult.Add(new(email.Id.Value.ToString(), email.Value, email.IsActive));
        }

        var phonesResult = new List<PhoneResult>();
        foreach (var phone in client.Phones)
        {
            phonesResult.Add(new(phone.Id.Value.ToString(), phone.NationalId, phone.Value, phone.IsActive));
        }

        return new ClientResult(client.Id.Value.ToString(), client.Address, taxConditionResult, client.ClientName, client.Cuil, client.HasEmailNotification, emailsResult, client.HasPhoneNotification, phonesResult, client.Observation, client.HasCheckingAccount, client.IsWholesaler);
    }
}
