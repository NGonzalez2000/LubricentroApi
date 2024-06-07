namespace Lubricentro.Contracts.Companies;

public record CreateCompanyRequest(string Name,string Cuil, string Email, string Password)
{
}
