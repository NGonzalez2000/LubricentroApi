using FluentValidation;

namespace Lubricentro.Application.EmployeeMediator.Queries.GetById;

public class GetEmployeeByIdValidator : AbstractValidator<GetEmployeeByIdQuery>
{
    public GetEmployeeByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
