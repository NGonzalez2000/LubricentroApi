using ErrorOr;
using Lubricentro.Application.CompanyMediator.Common;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Commands.Update;

public record UpdateCompanyCommand(Guid Id, string Name, string Cuil, string Email,string Password) : IRequest<ErrorOr<CompanyResult>>
{
}
