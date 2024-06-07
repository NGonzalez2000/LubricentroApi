namespace Lubricentro.Contracts.Companies;

public record UpdateCompanyRequest(Guid Id, string Name, string Cuil, string Email, string Password)
{
}
