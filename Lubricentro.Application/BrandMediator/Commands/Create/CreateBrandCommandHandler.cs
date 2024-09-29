using ErrorOr;
using Lubricentro.Application.BrandMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.BrandAggregate;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.ProviderAggregate;
using Lubricentro.Domain.ProviderAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.BrandMediator.Commands.Create;

internal class CreateBrandCommandHandler(IBrandRepository brandRepository, IProviderRepository providerRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateBrandCommand, ErrorOr<BrandResult>>
{
    public async Task<ErrorOr<BrandResult>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        if(await brandRepository.GetByNameAsync(request.Name) is not null)
        {
            return Errors.Brands.DuplicatedName;
        }

        if(providerRepository.GetById(ProviderId.Create(request.ProviderId)) is not Provider provider)
        {
            return Errors.Providers.NotFound;
        }

        Brand newBrand = Brand.Create(request.Name);
        provider.AddBrand(newBrand);

        providerRepository.Update(provider);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new BrandResult(newBrand);
    }

}
