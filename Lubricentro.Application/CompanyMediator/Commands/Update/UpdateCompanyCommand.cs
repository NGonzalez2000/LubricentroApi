using ErrorOr;
using Lubricentro.Application.CompanyMediator.Common;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Commands.Update;

public record UpdateCompanyCommand(Guid Id, string Name, string Cuil) : IRequest<ErrorOr<CompanyResult>>
{
}
