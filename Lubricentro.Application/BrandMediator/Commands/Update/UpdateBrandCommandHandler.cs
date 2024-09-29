using ErrorOr;
using Lubricentro.Application.BrandMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.BrandAggregate;
using Lubricentro.Domain.BrandAggregate.ValueObjects;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.ProviderAggregate.ValueObjects;
using Lubricentro.Domain.ProviderAggregate;
using MediatR;

namespace Lubricentro.Application.BrandMediator.Commands.Update;

internal class UpdateBrandCommandHandler(IBrandRepository brandRepository,IProviderRepository providerRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateBrandCommand, ErrorOr<BrandResult>>
{
    public async Task<ErrorOr<BrandResult>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        if(await brandRepository.GetByIdAsync(BrandId.Create(request.Id)) is not Brand brand)
        {
            return Errors.Brands.NotFound;
        }

        if(await brandRepository.GetByNameAsync(request.Name) is Brand tempBrand && tempBrand.Id != brand.Id)
        {
            return Errors.Brands.DuplicatedName;
        }

        if (providerRepository.GetById(ProviderId.Create(request.ProviderId)) is not Provider provider)
        {
            return Errors.Providers.NotFound;
        }

        brand.Update(request.Name);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new BrandResult(brand);
    }
}
