using Lubricentro.Contracts.Providers;

namespace Lubricentro.Contracts.Brands;

public record BrandResponse(string Id, string Name, ProviderResponse Provider)
{
}
