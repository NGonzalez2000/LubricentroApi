using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Application.CompanyMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.CompanyAggregate;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Commands.Delete;

public class DeleteCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCompanyCommand, ErrorOr<CompanyResult>>
{
    private readonly ICompanyRepository _companyRepository = companyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<CompanyResult>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        if(await _companyRepository.GetByIdAsync(CompanyId.Create(request.Id)) is not Company company)
        {
            return Errors.Companies.NotFound;
        }

        _companyRepository.Delete(company);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CompanyResult(company.Id.Value.ToString(), company.Name);

    }
}
