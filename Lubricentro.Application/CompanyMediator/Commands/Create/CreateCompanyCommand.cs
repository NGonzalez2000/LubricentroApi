using ErrorOr;
using Lubricentro.Application.CompanyMediator.Common;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Commands.Create;

public record CreateCompanyCommand(string Name,string Cuil) : IRequest<ErrorOr<CompanyResult>>
{
}
