using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.EmailMediator;
using Lubricentro.Application.PhoneMediator;
using Lubricentro.Application.ProviderMediator.Common;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.ProviderAggregate;
using MediatR;

namespace Lubricentro.Application.ProviderMediator.Queries;

internal class GetAllProvidersQueryHandler(IProviderRepository providerRepository) : IRequestHandler<GetAllProvidersQuery, ErrorOr<List<ProviderResult>>>
{
    public async Task<ErrorOr<List<ProviderResult>>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
    {
        List<ProviderResult> result = [];
        
        var providers = await providerRepository.GetAllAsync();
        foreach (var provider in providers)
        {
            result.Add(new ProviderResult(provider));
        }
        return result;
    }
}
