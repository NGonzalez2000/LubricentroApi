using Lubricentro.Application.CompanyMediator.Common;
using Lubricentro.Contracts.Companies;
using Mapster;

namespace Lubricentro.Api.Common.Mapping
{
    public class CompanyMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CompanyResult, CompanyResponse>();
        }
    }
}
