using ErrorOr;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using Lubricentro.Domain.TaxConditionAggregate;
using MediatR;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;

namespace Lubricentro.Application.TaxConditionMediator.Commands.Update;

internal class UpdateTaxConditionCommandHandler(ITaxConditionRepository taxConditionRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateTaxConditionCommand, ErrorOr<TaxConditionResult>>
{
    private readonly ITaxConditionRepository _taxConditionRepository = taxConditionRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<TaxConditionResult>> Handle(UpdateTaxConditionCommand request, CancellationToken cancellationToken)
    {
        if (_taxConditionRepository.GetById(TaxConditionId.Create(request.Id)) is not TaxCondition taxCondition)
        {
            return Errors.TaxConditions.NotFound;
        }

        taxCondition.Update(request.Description, request.Type, request.Vat);

        _taxConditionRepository.Update(taxCondition);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new TaxConditionResult(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT);
    }
}
