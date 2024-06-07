using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.TaxConditionMediator.Common;
using MediatR;

namespace Lubricentro.Application.TaxConditionMediator.Queries.GetAll;

public class GetTaxConditionsQueryHandler(ITaxConditionRepository taxConditionRepository) : IRequestHandler<GetTaxConditionsQuery, ErrorOr<List<TaxConditionResult>>>
{
    private readonly ITaxConditionRepository _taxConditionRepository = taxConditionRepository;
    public async Task<ErrorOr<List<TaxConditionResult>>> Handle(GetTaxConditionsQuery request, CancellationToken cancellationToken)
    {
        var taxConditions = await _taxConditionRepository.GetAllAsync();
        var results = new List<TaxConditionResult>();

        foreach (var taxCondition in taxConditions)
        {
            results.Add(new(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT));
        }

        return results;
    }
}
