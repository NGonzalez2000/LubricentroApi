using Lubricentro.Application.BrandMediator.Common;
using Lubricentro.Application.ProviderMediator.Common;
using Lubricentro.Domain.ProductAggregate;

namespace Lubricentro.Application.ProductMediator.Common;

public record ProductResult(string Id,
                            string Code,
                            string Barcode,
                            string Description,
                            string ProviderId,
                            string ProviderName,
                            BrandResult Brand,
                            decimal ListPrice,
                            decimal SellPrice,
                            decimal MarkupPercentage,
                            bool IsWholesaler,
                            bool IsUsd)
{
    public ProductResult(Product product) : this(product.Id.Value.ToString(),
                                                 product.Code,
                                                 product.Barcode,
                                                 product.Description,
                                                 product.Provider.Id.Value.ToString(),
                                                 product.Provider.Name,
                                                 new BrandResult(product.Brand),
                                                 product.ListPrice,
                                                 product.SellPrice,
                                                 product.MarkupPercentage,
                                                 product.IsWholesaler,
                                                 product.IsUsd)
    {

    }
}
