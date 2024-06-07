using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.TaxConditionMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.TaxConditionAggregate;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.TaxConditionMediator.Commands.Delete;

internal class DeleteTaxConditionCommandHandler(ITaxConditionRepository taxConditionRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteTaxConditionCommand, ErrorOr<TaxConditionResult>>
{
    private readonly ITaxConditionRepository _taxConditionRepository = taxConditionRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<TaxConditionResult>> Handle(DeleteTaxConditionCommand request, CancellationToken cancellationToken)
    {
        if(_taxConditionRepository.GetById(TaxConditionId.Create(request.Id)) is not TaxCondition taxCondition)
        {
            return Errors.TaxConditions.NotFound;
        }

        _taxConditionRepository.Delete(taxCondition);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new TaxConditionResult(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT);
    }
}
