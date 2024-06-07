using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.TaxConditionAggregate;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.MigrationMediator.TaxConditionMediator.Commands.Update;

internal class UpdateTaxConditionMigrationCommandHandler(ITaxConditionRepository taxConditionRepository, ITaxConditionMigrationRepository taxConditionMigrationRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateTaxConditionMigrationCommand, ErrorOr<TaxConditionMigrationResult>>
{
    private readonly ITaxConditionRepository _taxConditionRepository = taxConditionRepository;
    private readonly ITaxConditionMigrationRepository _taxConditionMigrationRepository = taxConditionMigrationRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<TaxConditionMigrationResult>> Handle(UpdateTaxConditionMigrationCommand request, CancellationToken cancellationToken)
    {

        if(_taxConditionRepository.GetById(TaxConditionId.Create(request.Id)) is not TaxCondition taxCondition)
        {
            var taxConditionsMigrated = await _taxConditionMigrationRepository.GetAllAsync();

            foreach(var taxConditionMigrated in taxConditionsMigrated)
            {
                if(taxConditionMigrated.TaxConditionId == request.Id.ToString())
                {
                    _taxConditionMigrationRepository.Delete(taxConditionMigrated);
                }
            }

            return Errors.TaxConditions.NotFound;
        }

        if(_taxConditionRepository.GetByDescription(request.Description) is TaxCondition temp && temp.Id != taxCondition.Id)
        {
            return Errors.TaxConditions.Duplicated;
        }

        taxCondition.Update(request.Description, taxCondition.Type, taxCondition.VAT);

        _taxConditionRepository.Update(taxCondition);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new TaxConditionMigrationResult(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT);

    }
}
