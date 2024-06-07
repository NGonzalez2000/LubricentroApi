using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;
using Lubricentro.Application.Common.Interfaces.Persistence.OldDb;
using Lubricentro.Application.MigrationMediator.ClientMediator.Common;
using MediatR;

namespace Lubricentro.Application.MigrationMediator.ClientMediator.Queries;

internal class GetAllOldClientsQueryHandler(IClientMigrationRepository _clientMigrationRepository, IOldClientRepository _oldClientRepository, ITaxConditionRepository _taxConditionRepository, ITaxConditionMigrationRepository _taxConditionMigrationRepository) : IRequestHandler<GetAllOldClientsQuery, ErrorOr<List<OldClientResult>>>
{
    public async Task<ErrorOr<List<OldClientResult>>> Handle(GetAllOldClientsQuery request, CancellationToken cancellationToken)
    {
        var oldClients = await _oldClientRepository.GetAllAsync();
        var taxConditionsMapper = await _taxConditionMigrationRepository.GetAllAsync();
        var newTaxConditions = await _taxConditionRepository.GetAllAsync();
        var results = new List<OldClientResult>();

        Dictionary<int, string> map = [];

        foreach(var taxCondition in taxConditionsMapper)
        {
            map.Add(taxCondition.Tcl_Codigo, taxCondition.TaxConditionId);
        }

        foreach (var oldClient in oldClients)
        {
            var taxCondition = newTaxConditions.ElementAt(newTaxConditions.FindIndex(tc => tc.Id.Value.ToString() == map[oldClient.Tcl_Codigo]));

            var clientMigration = await _clientMigrationRepository.GetByClientId(oldClient.Cli_Codigo);

            string id;
            if(clientMigration != null)
            {
                id = clientMigration.ClientId;
            }
            else
            {
                id = oldClient.Cli_Codigo.ToString();
            }


            OldClientResult result = new(id,
                                         "",
                                         "",
                                         oldClient.Cli_Provincia.Trim(),
                                         oldClient.Cli_Localidad.Trim(),
                                         oldClient.Cli_Direccion.Trim(),
                                         oldClient.Cli_CP.Trim(),
                                         taxCondition.Id.Value.ToString(),
                                         taxCondition.Description,
                                         taxCondition.Type,
                                         taxCondition.VAT,
                                         oldClient.Cli_Nombre.Trim(),
                                         oldClient.Cli_Cuit.Trim(),
                                         oldClient.Cli_Email.Trim(),
                                         oldClient.Cli_Telefono.Trim(),
                                         oldClient.Cli_Celular.Trim(),
                                         "",
                                         oldClient.Cli_Cta_Cte,
                                         oldClient.Cli_Mayorista == 1);
            results.Add(result);
        }

        return results;
    }
}
