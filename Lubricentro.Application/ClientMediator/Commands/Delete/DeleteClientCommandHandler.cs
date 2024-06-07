using ErrorOr;
using Lubricentro.Application.ClientMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.ClientAggregate;
using Lubricentro.Domain.ClientAggregate.ValueObjects;
using Lubricentro.Domain.Common.Errors;
using MediatR;

namespace Lubricentro.Application.ClientMediator.Commands.Delete;

internal class DeleteClientCommandHandler(IClientRepository clientRepository, IAddressRepository addressRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteClientCommand, ErrorOr<ClientResult>>
{
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IAddressRepository _addressRepository = addressRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<ClientResult>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        if(_clientRepository.GetClientById(ClientId.Create(request.Id))is not Client client)
        {
            return Errors.Clients.NotFounnd;
        }

        _clientRepository.Delete(client);

        _addressRepository.Delete(client.Address);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        TaxConditionResult taxConditionResult = new("","",'A',false);

        return new ClientResult(client.Id.Value.ToString(), client.Address, taxConditionResult, client.ClientName, client.Cuil, client.Email, client.PhoneNumber, client.CellphoneNumber, client.Observation, client.HasCheckingAccount, client.IsWholesaler);
    }
}
