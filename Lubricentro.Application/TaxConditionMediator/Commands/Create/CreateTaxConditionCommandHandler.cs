using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.MigrationAggregates;
using Lubricentro.Domain.TaxConditionAggregate;
using MediatR;

namespace Lubricentro.Application.TaxConditionMediator.Commands.Create;

internal class CreateTaxConditionCommandHandler(ITaxConditionRepository taxConditionRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateTaxConditionCommand, ErrorOr<TaxConditionResult>>
{
    private readonly ITaxConditionRepository _taxConditionRepository = taxConditionRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<TaxConditionResult>> Handle(CreateTaxConditionCommand request, CancellationToken cancellationToken)
    {
        if(_taxConditionRepository.GetByDescription(request.Description) is not null)
        {
            return Errors.TaxConditions.Duplicated;
        }

        var taxCondition = TaxCondition.Create(request.Description, request.Type, request.Vat);

        _taxConditionRepository.Add(taxCondition);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new TaxConditionResult(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT);
    }
}
