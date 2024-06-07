namespace Lubricentro.Contracts.Companies;

public record UpdateCompanyServicesRequest(List<CompanyServiceRequest> CompanyServices)
{
}

public record CompanyServiceRequest(Guid Id, Guid CompanyId);
