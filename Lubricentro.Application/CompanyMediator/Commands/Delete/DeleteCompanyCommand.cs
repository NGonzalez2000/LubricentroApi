using ErrorOr;
using Lubricentro.Application.CompanyMediator.Common;
using MediatR;

namespace Lubricentro.Application.CompanyMediator.Commands.Delete;

public record DeleteCompanyCommand(Guid Id) : IRequest<ErrorOr<CompanyResult>>
{
}
