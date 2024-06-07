using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.CompanyMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.CompanyAggregate;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Commands.Update;

public class UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateCompanyCommand, ErrorOr<CompanyResult>>
{
    private readonly ICompanyRepository _companyRepository = companyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<CompanyResult>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        if(await _companyRepository.GetByIdAsync(CompanyId.Create(request.Id)) is not Company company)
        {
            return Errors.Companies.NotFound;
        }

        if(await _companyRepository.GetByNameAsync(request.Name) is not null)
        {
            return Errors.Companies.Duplicated;
        }

        company.ChangeCompanyName(request.Name);
        company.ChangeCuil(request.Cuil);
        company.ChangeEmail(request.Email);
        company.ChangePassword(request.Password);

        _companyRepository.Update(company);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CompanyResult(company.Id.Value.ToString(), company.Name, company.Cuil, company.Email, company.Password);
    }
}
