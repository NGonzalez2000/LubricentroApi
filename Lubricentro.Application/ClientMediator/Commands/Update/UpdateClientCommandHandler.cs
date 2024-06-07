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

        client.Update(request.Country, request.State, request.City, request.Street, request.PostalCode, taxCondition, request.ClientName, request.Cuil, request.Email, request.PhoneNumber, request.CellphoneNumber, request.Observation, request.HasCheckingAccount, request.IsWholesaler);

        _clientRepository.Update(client);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var taxConditionResult = new TaxConditionResult(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT);

        return new ClientResult(client.Id.Value.ToString(), client.Address, taxConditionResult, client.ClientName, client.Cuil, client.Email, client.PhoneNumber, client.CellphoneNumber, client.Observation, client.HasCheckingAccount, client.IsWholesaler);
    }
}
