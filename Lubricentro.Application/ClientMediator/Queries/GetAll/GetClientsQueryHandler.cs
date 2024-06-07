using ErrorOr;
using Lubricentro.Application.ClientMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.ClientMediator.Queries.GetAll;

internal class GetClientsQueryHandler(IClientRepository clientRepository) : IRequestHandler<GetClientsQuery, ErrorOr<List<ClientResult>>>
{
    private readonly IClientRepository _clientRepository = clientRepository;
    public async Task<ErrorOr<List<ClientResult>>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        var clients = await _clientRepository.GetAllAsync();
        var results = new List<ClientResult>();
        foreach (var client in clients)
        {
            TaxConditionResult taxConditionResult = new(client.TaxCondition.Id.Value.ToString(), client.TaxCondition.Description, client.TaxCondition.Type, client.TaxCondition.VAT);
            results.Add(new ClientResult(client.Id.Value.ToString(), client.Address, taxConditionResult, client.ClientName, client.Cuil, client.Email, client.PhoneNumber, client.CellphoneNumber, client.Observation, client.HasCheckingAccount, client.IsWholesaler));
        }
        return results;
    }
}
