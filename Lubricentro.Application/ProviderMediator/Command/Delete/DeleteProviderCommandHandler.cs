using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.ProviderMediator.Common;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.ProviderAggregate;
using Lubricentro.Domain.ProviderAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.ProviderMediator.Command.Delete
{
    internal class DeleteProviderCommandHandler(IProviderRepository providerRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteProviderCommand, ErrorOr<ProviderResult>>
    {
        public async Task<ErrorOr<ProviderResult>> Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
        {
            if (providerRepository.GetById(ProviderId.Create(request.Id)) is not Provider provider)
                return Errors.Providers.NotFound;

            providerRepository.Delete(provider);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new ProviderResult(provider);
        }
    }
}
