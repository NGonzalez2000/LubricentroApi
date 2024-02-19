using Lubricentro.Application.RoleMediator.Command.Update;
using Lubricentro.Application.RoleMediator.Common;
using Lubricentro.Contracts.Roles;
using Lubricentro.Domain.PolicyAggregate;
using Mapster;

namespace Lubricentro.Api.Common.Mapping
{
    public class RoleMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RoleResult, RoleResponse>()
                .Map(dest => dest, src => src.Role)
                .Map(dest => dest.Id, src => src.Role.Id.Value.ToString())
                .Map(dest => dest.Policies, src => src.Role.Policies);

            config.NewConfig<Policy, PolicyResponse>()
                .Map(dest => dest.Id, src => src.Id.Value.ToString());

            
        }
    }
}
