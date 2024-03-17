using Lubricentro.Application.EmployeeMediator.Common;
using Lubricentro.Application.EmployeeMediator.Queries.GetById;
using Lubricentro.Contracts.Employees;
using Mapster;

namespace Lubricentro.Api.Common.Mapping;

public class EmployeeMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EmployeeResult, EmployeeResponse>();


        config.NewConfig<GetEmployeeByIdQuery, GetEmployeeByIdRequest>();
    }
}
