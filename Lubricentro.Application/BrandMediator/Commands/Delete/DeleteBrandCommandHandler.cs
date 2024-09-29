using ErrorOr;
using Lubricentro.Application.BrandMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.BrandAggregate.ValueObjects;
using Lubricentro.Domain.BrandAggregate;
using MediatR;
using Lubricentro.Domain.Common.Errors;

namespace Lubricentro.Application.BrandMediator.Commands.Delete;

internal class DeleteBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteBrandCommand, ErrorOr<BrandResult>>
{
    public async Task<ErrorOr<BrandResult>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        if (await brandRepository.GetByIdAsync(BrandId.Create(request.Id)) is not Brand brand)
        {
            return Errors.Brands.NotFound;
        }

        brandRepository.Delete(brand);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new BrandResult(brand);
    }
}
