namespace Lubricentro.Contracts.Products;

public record UpdateProductRequest(Guid Id,
                                   string Code,
                                   string Barcode,
                                   string Description,
                                   Guid ProviderId,
                                   Guid BrandId,
                                   decimal ListPrice,
                                   decimal SellPrice,
                                   decimal MarkupPercentage,
                                   bool IsWholesaler,
                                   bool IsUsd)
{
}
