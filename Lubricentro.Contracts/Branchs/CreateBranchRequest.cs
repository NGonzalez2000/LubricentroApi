namespace Lubricentro.Contracts.Branchs;

public record CreateBranchRequest(Guid CompanyId, string Name, string PointOfSale, string Country, string State, string City, string Street, string PostalCode)
{
}
