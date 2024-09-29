using ErrorOr;
using Lubricentro.Application.ProductMediator.Common;
using MediatR;

namespace Lubricentro.Application.ProductMediator.Command.Create;

public record CreateProductCommand(string Code,
                                   string Barcode,
                                   string Description,
                                   Guid ProviderId,
                                   Guid BrandId,
                                   decimal ListPrice,
                                   decimal SellPrice,
                                   decimal MarkupPercentage,
                                   bool IsWholesaler,
                                   bool IsUsd) : IRequest<ErrorOr<ProductResult>>
{
}
