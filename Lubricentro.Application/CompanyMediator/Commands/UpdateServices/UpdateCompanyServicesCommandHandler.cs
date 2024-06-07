using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.CompanyMediator.Common;
using Lubricentro.Domain.CompanyAggregate;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Commands.UpdateServices;

internal class UpdateCompanyServicesCommandHandler(ICompanyServiceRepository _companyServiceRepository, ICompanyRepository _companyRepository, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateCompanyServicesCommand, ErrorOr<List<CompanyServiceResult>>>
{
    public async Task<ErrorOr<List<CompanyServiceResult>>> Handle(UpdateCompanyServicesCommand request, CancellationToken cancellationToken)
    {
        var companyServices = await _companyServiceRepository.GetAllAsync();
        var companies = await _companyRepository.GetAllAsync();

        Company? temp;
        foreach (var service in request.CompanyServices)
        {
            temp = companies.FirstOrDefault(c => c.Id.Value == service.CompanyId);
            int indx = companyServices.FindIndex(cs => cs.Id.Value == service.Id);
            if (indx != -1)
            {
                companyServices[indx].SetCompany(temp);
            }
        }
        _companyServiceRepository.UpdateAllAsync(companyServices);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var result = new List<CompanyServiceResult>();
        CompanyResult? companyResult;

        foreach (var service in companyServices)
        {
            companyResult = null;
            if(service.Company is not null)
            {
                companyResult = new(service.Company.Id.Value.ToString(), service.Company.Name, service.Company.Cuil, service.Company.Email, service.Company.Password);
            }
            result.Add(new CompanyServiceResult(service.Id.Value.ToString(),
                                                service.Name,
                                                companyResult
                                               ));
        }

        return result;
    }
}
