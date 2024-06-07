using ErrorOr;
using Lubricentro.Application.ClientMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.TaxConditionAggregate;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using MediatR;

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

        var client = Client.Create(address, taxCondition, request.ClientName, request.Cuil, request.Email, request.PhoneNumber, request.CellphoneNumber, request.Observation, request.HasCheckingAccount, request.IsWholesaler);

        _clientRepository.Add(client);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var taxConditionResult = new TaxConditionResult(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT);

        return new ClientResult(client.Id.Value.ToString(), client.Address, taxConditionResult, client.ClientName, client.Cuil, client.Email, client.PhoneNumber, client.CellphoneNumber, client.Observation, client.HasCheckingAccount, client.IsWholesaler);
    }
}
