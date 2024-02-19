using Lubricentro.Application.Authentication.Common;
using Lubricentro.Application.Authentication.Queries.Login;
using Lubricentro.Contracts.Authentication;
using Mapster;

namespace Lubricentro.Api.Common.Mapping
{
    public class AuthenticationMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LoginQuery>();

            
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src);
        }
    }
}
