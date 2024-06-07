using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.CompanyMediator.Common;
using Lubricentro.Domain.CompanyAggregate;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Queries.GetServices;

internal class GetAllCompanyServicesQueryHandler(ICompanyServiceRepository _companyServiceRepository) : IRequestHandler<GetAllCompanyServicesQuery, ErrorOr<List<CompanyServiceResult>>>
{
    public async Task<ErrorOr<List<CompanyServiceResult>>> Handle(GetAllCompanyServicesQuery request, CancellationToken cancellationToken)
    {
        var services = await _companyServiceRepository.GetAllAsync();
        List<CompanyServiceResult> result = [];

        CompanyResult? companyResult;
        foreach (var service in services)
        {
            companyResult = null;
            if(service.Company is Company company)
            {
                companyResult = new(company.Id.Value.ToString(), company.Name, company.Cuil, company.Email, company.Password);
            }
            result.Add(new CompanyServiceResult(
                service.Id.Value.ToString(),
                service.Name,
                companyResult)
                );
        }
        return result;
    }
}
