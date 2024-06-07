using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;
using Lubricentro.Application.MigrationMediator.TaxConditionMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.MigrationAggregates;
using Lubricentro.Domain.TaxConditionAggregate;
using MediatR;
namespace Lubricentro.Application.MigrationMediator.TaxConditionMediator.Commands.Create;

internal class CreateTaxConditionMigrationCommandHandler(ITaxConditionRepository taxConditionRepository, ITaxConditionMigrationRepository taxConditionMigrationRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateTaxConditionMigrationCommand, ErrorOr<TaxConditionMigrationResult>>
{
    private readonly ITaxConditionRepository _taxConditionRepository = taxConditionRepository;
    private readonly ITaxConditionMigrationRepository _taxConditionMigrationRepository = taxConditionMigrationRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ErrorOr<TaxConditionMigrationResult>> Handle(CreateTaxConditionMigrationCommand request, CancellationToken cancellationToken)
    {
        if (_taxConditionRepository.GetByDescription(request.Description) is not null)
        {
            return Errors.TaxConditions.Duplicated;
        }

        var taxCondition = TaxCondition.Create(request.Description, request.Type, request.Vat);
        var taxConditionMigration = TaxConditionMigration.Create(taxCondition.Id.Value.ToString(), int.Parse(request.OldId));

        _taxConditionRepository.Add(taxCondition);
        _taxConditionMigrationRepository.Add(taxConditionMigration);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new TaxConditionMigrationResult(taxCondition.Id.Value.ToString(), taxCondition.Description, taxCondition.Type, taxCondition.VAT);
    }
}
