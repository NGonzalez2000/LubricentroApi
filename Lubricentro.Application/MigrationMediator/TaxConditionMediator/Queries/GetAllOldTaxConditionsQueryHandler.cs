using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;
using Lubricentro.Application.Common.Interfaces.Persistence.OldDb;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using MediatR;

namespace Lubricentro.Application.MigrationMediator.TaxConditionMediator.Queries;

internal class GetAllOldTaxConditionsQueryHandler(ITaxConditionMigrationRepository taxConditionMigrationRepository, IOldTaxConditionRepository oldTaxConditionRepository) : IRequestHandler<GetAllOldTaxConditionsQuery, ErrorOr<List<OldTaxConditionResult>>>
{
    private readonly ITaxConditionMigrationRepository _taxConditionMigrationRepository = taxConditionMigrationRepository;
    private readonly IOldTaxConditionRepository _oldTaxConditionRepository = oldTaxConditionRepository;
    public async Task<ErrorOr<List<OldTaxConditionResult>>> Handle(GetAllOldTaxConditionsQuery request, CancellationToken cancellationToken)
    {
        var taxConditionsMapping = await _taxConditionMigrationRepository.GetAllAsync();
        var oldTaxConditions = await _oldTaxConditionRepository.GetAllAsync();
        var results = new List<OldTaxConditionResult>();

        foreach (var taxCondition in oldTaxConditions)
        {
            OldTaxConditionResult result;
            var mappedTaxCondition = taxConditionsMapping.FirstOrDefault(tc => tc.Tcl_Codigo == taxCondition.Tcl_Codigo);

            if (mappedTaxCondition != null)
            {
                result = new(mappedTaxCondition.TaxConditionId, taxCondition.Tcl_descripcion.Trim(), taxCondition.Tcl_Tipo_Factura, taxCondition.Tcl_Iva_Discriminado);
            }
            else
            {
                result = new(taxCondition.Tcl_Codigo.ToString(), taxCondition.Tcl_descripcion.Trim(), taxCondition.Tcl_Tipo_Factura, taxCondition.Tcl_Iva_Discriminado);
            }

            results.Add(result);
        }

        return results;
    }
}
