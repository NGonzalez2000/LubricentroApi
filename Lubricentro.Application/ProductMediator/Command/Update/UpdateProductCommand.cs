using ErrorOr;
using Lubricentro.Application.ProductMediator.Common;
using MediatR;

namespace Lubricentro.Application.ProductMediator.Command.Update;

public record UpdateProductCommand(Guid Id,
                                   string Code,
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
