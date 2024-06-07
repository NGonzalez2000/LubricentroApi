using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.CompanyMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.CompanyAggregate;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Commands.Create;

public class CreateCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateCompanyCommand, ErrorOr<CompanyResult>>
{
    private readonly ICompanyRepository _companyRepository = companyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<CompanyResult>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        if (await _companyRepository.GetByNameAsync(request.Name) is not null)
        {
            return Errors.Companies.Duplicated;
        }

        Company company = Company.Create(request.Name, request.Cuil, request.Email, request.Password);

        _companyRepository.Add(company);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CompanyResult(company.Id.Value.ToString(), company.Name, company.Cuil, company.Email, company.Password);
    }
}
