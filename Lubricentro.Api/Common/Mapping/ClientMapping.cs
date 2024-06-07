using Lubricentro.Application.ClientMediator.Commands.Create;
using Lubricentro.Application.ClientMediator.Common;
using Lubricentro.Contracts.Clients;
using Mapster;

namespace Lubricentro.Api.Common.Mapping
{
    public class ClientMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ClientResult, ClientResponse>()
                .Map(dest => dest, src => src)
                .Map(dest => dest.AddressId, src => src.Address.Id.Value.ToString())
                .Map(dest => dest.Country, src => src.Address.Country)
                .Map(dest => dest.State, src => src.Address.State)
                .Map(dest => dest.City, src => src.Address.City)
                .Map(dest => dest.Street, src => src.Address.Street)
                .Map(dest => dest.PostalCode, src => src.Address.PostalCode);
        }
    }
}
