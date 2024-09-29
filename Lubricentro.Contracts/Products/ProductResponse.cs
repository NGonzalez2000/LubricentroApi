using Lubricentro.Contracts.Brands;
using Lubricentro.Contracts.Providers;

namespace Lubricentro.Contracts.Products;

public record ProductResponse(string Id,
                              string Code,
                              string Barcode,
                              string Description,
                              string ProviderId,
                              string ProviderName,
                              BrandResponse Brand,
                              decimal ListPrice,
                              decimal SellPrice,
                              decimal MarkupPercentage,
                              bool IsWholesaler,
                              bool IsUsd)
{
}
