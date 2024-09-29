using ErrorOr;
using Lubricentro.Application.ClientMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.PhoneMediator;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.EmailAggregates;
using Lubricentro.Domain.PhoneAggregate;
using Lubricentro.Domain.TaxConditionAggregate;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Http.Json;

namespace Lubricentro.Application.ClientMediator.Commands.Create;

internal class CreateClientCommandHandler(IClientRepository clientRepository, ITaxConditionRepository taxConditionRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateClientCommand, ErrorOr<ClientResult>>
{
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly ITaxConditionRepository _taxConditionRepository = taxConditionRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<ClientResult>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        if(_clientRepository.GetClientByCuil(request.Cuil) is not null)
        {
            return Errors.Clients.DuplicatedCuil;
        }

        if(_taxConditionRepository.GetById(TaxConditionId.Create(request.TaxConditionId)) is not TaxCondition taxCondition)
        {
            return Errors.TaxConditions.NotFound;
        }

        var address = Address.Create(request.Country, request.State, request.City, request.Street, request.PostalCode);

        List<Email> emails = [];
        foreach(var email in request.Emails)
        {
            emails.Add(Email.Create(email.Value, email.IsActive));
        }

        List<Phone> phones = [];
        foreach (var phone in request.Phones)
        {
            phones.Add(Phone.Create(phone.NationalId, phone.Value, phone.IsActive));
        }

        var client = Client.Create(address,
                                   taxCondition,
                                   request.ClientName,
                                   request.Cuil,
                                   request.HasEmailNotification,
                                   emails,
                                   request.HasPhoneNotification,
                                   phones,
                                   request.Observation,
                                   request.HasCheckingAccount,
                                   request.IsWholesaler);

        _clientRepository.Add(client);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var taxConditionResult = new TaxConditionResult(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT);
        var emailsResult = new List<EmailResult>();
        foreach(var email in client.Emails)
        {
            emailsResult.Add(new(email.Id.Value.ToString(), email.Value, email.IsActive));
        }
        var phonesResult = new List<PhoneResult>();
        foreach (var phone in client.Phones)
        {
            phonesResult.Add(new(phone.Id.Value.ToString(), phone.NationalId, phone.Value, phone.IsActive));
        }
        return new ClientResult(client.Id.Value.ToString(), client.Address, taxConditionResult, client.ClientName, client.Cuil,client.HasEmailNotification, emailsResult, client.HasPhoneNotification, phonesResult, client.Observation, client.HasCheckingAccount, client.IsWholesaler);
    }
}
