using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.ProductMediator.Common;
using Lubricentro.Domain.BrandAggregate;
using Lubricentro.Domain.BrandAggregate.ValueObjects;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.ProductAggregate;
using Lubricentro.Domain.ProviderAggregate;
using Lubricentro.Domain.ProviderAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.ProductMediator.Command.Create;

internal class CreateProductCommandHanlder(IProductRepository productRepository,
                                           IBrandRepository brandRepository,
                                           IProviderRepository providerRepository,
                                           IStockRepository stockRepository,
                                           IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, ErrorOr<ProductResult>>
{
    public async Task<ErrorOr<ProductResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if(productRepository.CheckIfExists(request.Code, request.Barcode))
        {
            return Errors.Products.Duplicated;
        }

        if(await brandRepository.GetByIdAsync(BrandId.Create(request.BrandId)) is not Brand brand)
        {
            return Errors.Brands.NotFound;
        }

        if(providerRepository.GetById(ProviderId.Create(request.ProviderId)) is not Provider provider)
        {
            return Errors.Providers.NotFound;
        }

        var newProduct = Product.Create(request.Code,
                                        request.Barcode,
                                        request.Description,
                                        provider,
                                        brand,
                                        request.ListPrice,
                                        request.SellPrice,
                                        request.MarkupPercentage,
                                        request.IsWholesaler,
                                        request.IsUsd);

        productRepository.Add(newProduct);

        var stocks = await stockRepository.GetStocks();

        foreach (var stock in stocks)
        {
            stock.AddItem(StockItem.Create(newProduct, StockItemLocation.Create("0","0","0")));
            stockRepository.Update(stock);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new ProductResult(newProduct);
    }
}
