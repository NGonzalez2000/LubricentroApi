namespace Lubricentro.Contracts.Brands;

public record UpdateBrandRequest(Guid Id, string Name, Guid ProviderId)
{
}
