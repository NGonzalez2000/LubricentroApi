namespace Lubricentro.Contracts.Branchs;

public record UpdateBranchRequest(Guid Id, string Name, string PointOfSale, string Country, string State, string City, string Street, string PostalCode)
{
}
