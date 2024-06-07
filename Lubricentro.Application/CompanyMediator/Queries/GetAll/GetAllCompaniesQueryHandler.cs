using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.CompanyMediator.Common;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Queries.GetAll;

public class GetAllCompaniesQueryHandler(ICompanyRepository companyRepository) : IRequestHandler<GetAllCompaniesQuery, ErrorOr<List<CompanyResult>>>
{
    private readonly ICompanyRepository _companyRepository = companyRepository;
    public async Task<ErrorOr<List<CompanyResult>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _companyRepository.GetAllAsync();
        List<CompanyResult> result = [];

        foreach (var company in companies)
        {
            result.Add(new(company.Id.Value.ToString(), company.Name, company.Cuil, company.Email, company.Password));
        }

        return result;
    }
}
