using Lubricentro.Application.MigrationMediator.ClientMediator.Common;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using Lubricentro.Contracts.Clients;
using Lubricentro.Contracts.Migrations.TaxCondition;
using Mapster;

namespace Lubricentro.Api.Common.Mapping;

public class MigrationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OldTaxConditionResult, OldTaxConditionResponse>()
            .Map(dest => dest.VAT, src => src.VAT);

        config.NewConfig<ClientMigrationResult, ClientResponse>()
            .Map(dest => dest, src => src)
            .Map(dest => dest.AddressId, src => src.Address.Id.Value.ToString())
            .Map(dest => dest.Country, src => src.Address.Country)
            .Map(dest => dest.State, src => src.Address.State)
            .Map(dest => dest.City, src => src.Address.City)
            .Map(dest => dest.Street, src => src.Address.Street)
            .Map(dest => dest.PostalCode, src => src.Address.PostalCode);
    }
}
