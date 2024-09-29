using ErrorOr;
using Lubricentro.Application.ClientMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.PhoneMediator;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.ClientMediator.Queries.GetAll;

internal class GetClientsQueryHandler(IClientRepository clientRepository) : IRequestHandler<GetClientsQuery, ErrorOr<List<ClientResult>>>
{
    public async Task<ErrorOr<List<ClientResult>>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        var clients = await clientRepository.GetAllAsync();
        var results = new List<ClientResult>();
        foreach (var client in clients)
        {
            TaxConditionResult taxConditionResult = new(client.TaxCondition.Id.Value.ToString(), client.TaxCondition.Description, client.TaxCondition.Type, client.TaxCondition.VAT);
            List<EmailResult> emailResults = [];
            foreach(var email in client.Emails)
            {
                emailResults.Add(new(email.Id.Value.ToString(), email.Value, email.IsActive));
            }

            List<PhoneResult> phoneResults = [];
            foreach (var phone in client.Phones)
            {
                phoneResults.Add(new(phone.Id.Value.ToString(), phone.NationalId, phone.Value, phone.IsActive));
            }
            results.Add(new ClientResult(client.Id.Value.ToString(), client.Address, taxConditionResult, client.ClientName, client.Cuil, client.HasEmailNotification, emailResults, client.HasPhoneNotification, phoneResults, client.Observation, client.HasCheckingAccount, client.IsWholesaler));
        }
        return results;
    }
}
