using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.PhoneMediator;
using Lubricentro.Application.ProviderMediator.Common;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.EmailAggregates;
using Lubricentro.Domain.PhoneAggregate;
using Lubricentro.Domain.ProviderAggregate;
using Lubricentro.Domain.ProviderAggregate.ValueObjects;
using Lubricentro.Domain.TaxConditionAggregate;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.ProviderMediator.Command.Update;

internal class UpdateProviderCommandHandler(IProviderRepository providerRepository, ITaxConditionRepository taxConditionRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateProviderCommand, ErrorOr<ProviderResult>>
{
    public async Task<ErrorOr<ProviderResult>> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
    {
        if (providerRepository.GetById(ProviderId.Create(request.Id)) is not Provider provider)
            return Errors.Providers.NotFound;

        if (taxConditionRepository.GetById(TaxConditionId.Create(request.TaxConditionId)) is not TaxCondition taxCondition)
            return Errors.TaxConditions.NotFound;

        provider.Update(request.Name,
                        request.Cuil,
                        request.Country,
                        request.State,
                        request.City,
                        request.Street,
                        request.PostalCode,
                        request.Fax,
                        request.Website,
                        request.Observation,
                        taxCondition);
        int i = 0;
        while (i < provider.Emails.Count)
        {
            Email temp = provider.Emails[i];
            if (!request.Emails.Any(x => x.Id == temp.Id.Value))
            {
                provider.DeleteEmail(i);
            }
            else i++;
        }
        foreach (EmailCommand temp in request.Emails)
        {
            if (temp.Id == Guid.Empty)
            {
                provider.AddEmail(Email.Create(temp.Value, temp.IsActive));
            }
            else
            {
                provider.UpdateEmail(temp.Id, temp.Value, temp.IsActive);
            }
        }

        i = 0;
        while (i < provider.Phones.Count)
        {
            Phone temp = provider.Phones[i];
            if (!request.Phones.Any(x => x.Id == temp.Id.Value))
            {
                provider.DeletePhone(i);
            }
            else i++;
        }
        foreach (PhoneCommand temp in request.Phones)
        {
            if (temp.Id == Guid.Empty)
            {
                provider.AddPhone(Phone.Create(temp.NationalId, temp.Value, temp.IsActive));
            }
            else
            {
                provider.UpdatePhone(temp.Id, temp.NationalId, temp.Value, temp.IsActive);
            }
        }
        providerRepository.Update(provider);
        await unitOfWork.SaveChangesAsync(cancellationToken);


        List<EmailResult> emailResults = [];
        foreach (var emailResult in provider.Emails)
        {
            emailResults.Add(new(emailResult.Id.Value.ToString(), emailResult.Value, emailResult.IsActive));
        }

        List<PhoneResult> phoneResults = [];
        foreach (var phoneResult in provider.Phones)
        {
            phoneResults.Add(new(phoneResult.Id.Value.ToString(), phoneResult.NationalId, phoneResult.Value, phoneResult.IsActive));
        }


        return new ProviderResult(provider);
    }
}
