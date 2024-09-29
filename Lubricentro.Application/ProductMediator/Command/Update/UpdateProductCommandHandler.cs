using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.ProductMediator.Common;
using Lubricentro.Domain.BrandAggregate;
using Lubricentro.Domain.BrandAggregate.ValueObjects;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.ProductAggregate;
using Lubricentro.Domain.ProductAggregate.ValueObjects;
using Lubricentro.Domain.ProviderAggregate;
using Lubricentro.Domain.ProviderAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.ProductMediator.Command.Update;

internal class UpdateProductCommandHandler(IProductRepository productRepository,IBrandRepository brandRepository, IProviderRepository providerRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductCommand, ErrorOr<ProductResult>>
{
    public async Task<ErrorOr<ProductResult>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        if(productRepository.GetById(ProductId.Create(request.Id)) is not Product product)
        {
            return Errors.Products.NotFound;
        }

        if(providerRepository.GetById(ProviderId.Create(request.ProviderId)) is not Provider provider)
        {
            return Errors.Providers.NotFound;
        }

        if(await brandRepository.GetByIdAsync(BrandId.Create(request.BrandId)) is not Brand brand)
        {
            return Errors.Brands.NotFound;
        }

        product.Update(request.Code,
                       request.Barcode,
                       request.Description,
                       provider,
                       brand,
                       request.ListPrice,
                       request.SellPrice,
                       request.MarkupPercentage,
                       request.IsWholesaler,
                       request.IsUsd);
        
        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new ProductResult(product);
    }
}
