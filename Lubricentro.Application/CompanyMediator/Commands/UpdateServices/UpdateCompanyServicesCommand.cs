using ErrorOr;
using Lubricentro.Application.CompanyMediator.Common;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Commands.UpdateServices;

public record UpdateCompanyServicesCommand(List<UpdateCompanyService> CompanyServices) : IRequest<ErrorOr<List<CompanyServiceResult>>>
{
}

public record UpdateCompanyService(Guid Id, string Name, Guid CompanyId);
