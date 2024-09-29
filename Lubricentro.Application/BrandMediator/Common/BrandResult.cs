using Lubricentro.Application.ProviderMediator.Common;
using Lubricentro.Domain.BrandAggregate;

namespace Lubricentro.Application.BrandMediator.Common;

public record BrandResult(string Id, string Name)
{
    public BrandResult(Brand brand) : this(brand.Id.Value.ToString(), brand.Name) { }
}
