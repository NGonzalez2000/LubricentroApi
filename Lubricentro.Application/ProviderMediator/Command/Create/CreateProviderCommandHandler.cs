using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.PhoneMediator;
using Lubricentro.Application.ProviderMediator.Common;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.EmailAggregates;
using Lubricentro.Domain.PhoneAggregate;
using Lubricentro.Domain.ProviderAggregate;
using Lubricentro.Domain.TaxConditionAggregate;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.ProviderMediator.Command.Create;

internal class CreateProviderCommandHandler(IProviderRepository providerRepository, ITaxConditionRepository taxConditionRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProviderCommand, ErrorOr<ProviderResult>>
{
    public async Task<ErrorOr<ProviderResult>> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
    {
        var providers = await providerRepository.GetAllAsync();
        if (providers.FirstOrDefault(p => p.Name == request.Name || p.Cuil == request.Cuil) is not null)
        {
            return Errors.Providers.Duplicated;
        }

        if (taxConditionRepository.GetById(TaxConditionId.Create(request.TaxConditionId)) is not TaxCondition taxCondition)
        {
            return Errors.TaxConditions.NotFound;
        }
        var newAddres = Address.Create(request.Country, request.State, request.City, request.Street, request.PostalCode);

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
        var newProvider = Provider.Create(request.Name, request.Cuil, newAddres, phones, request.Fax, emails, request.Website, request.Observation, taxCondition);

        providerRepository.Add(newProvider);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new ProviderResult(newProvider);
    }
}
